using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.RegularExpressions;
using WebScrapper.Data.Models;
using WebScrapper.Data.Repositories;

namespace WebScrapper.Domain.Services
{
    public class SearchService : ISearchService
    {
        private readonly IUnitOfWork _unitOfWork;
        private const string searchEngine = "https://www.google.co.uk/";
        private const int numberOfResults = 100;

        public SearchService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SearchResult>> GetHistory()
        {
            var searchResults = await _unitOfWork.SearcheResults.GetSearchHistoryAsync();

            return searchResults;
        }

        public async Task<SearchResult> Search(string url, string keywords)
        {
            if (keywords.Length == 0)
                throw new ArgumentException("Invalid keywords");

            if (string.IsNullOrEmpty(url))
                throw new ArgumentOutOfRangeException("Invalid url");

            var searchString = $"search?num={numberOfResults}&q={string.Join('+', keywords.Split(' '))}";

            var responseBody = await GetRequestResponse(searchString);

            var results = GetResults(responseBody, url);

            var searchResult = new SearchResult
            {
                Url = url,
                Keywords = keywords,
                Ranking = string.Join(", ", results),
                Occurrences = results.Count(),
                SearchDate = DateTime.UtcNow.ToLocalTime()
            };
            await SaveSearch(searchResult);

            return searchResult;
        }

        private async Task<string> GetRequestResponse(string keywords)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(searchEngine)
            };
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent",
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_14_0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.102 Safari/537.36");

            var response = await client.GetAsync(keywords);

            response.EnsureSuccessStatusCode();

            client.Dispose();

            return await response.Content.ReadAsStringAsync();
        }

        private List<string> GetResults(string responseBody, string url)
        {
            var regex = "href\\s*=\\s*(?:[\"'](?<1>[^\"']*)[\"']|(?<1>\\S+))";

            var results = new List<string>();

            var linksFounds = Regex.Match(responseBody, regex,
                            RegexOptions.IgnoreCase | RegexOptions.Compiled,
                            TimeSpan.FromSeconds(1));

            int position = 0;

            while (linksFounds.Success)
            {
                if (linksFounds.Groups[1].Value.Contains(url))
                {
                    results.Add(position.ToString());
                }

                linksFounds = linksFounds.NextMatch();

                position++;
            }

            return results;
        }

        private async Task SaveSearch(SearchResult search)
        {
            await _unitOfWork.SearcheResults.AddAsync(search);

            var result = await _unitOfWork.CompleteAsync();
        }
    }
}
