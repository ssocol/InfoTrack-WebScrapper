using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebScrapper.Api.Dtos;
using WebScrapper.Domain.Services;

namespace WebScrapper.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet("History")]
        public async Task<IActionResult> GetSearchHistory()
        {

            var history = await _searchService.GetHistory();

            if (history.Count() == 0)
                return NotFound();

            var result = history.Select(h => new SearchResultDto
            {
                Url = h.Url,
                Keywords = h.Keywords,
                Ranking = h.Occurrences > 0 ? h.Ranking : "0",
                Occurrences = h.Occurrences,
                SearchDate = h.SearchDate.ToString("dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture)
            }).ToList();

            return Ok(result);
        }

        [HttpPost("Search")]
        public async Task<IActionResult> Search([FromBody] SearchDto dto)
        {
            try
            {
                var result = await _searchService.Search(dto.Url, dto.Keywords);

                if (result == null)
                {
                    return NotFound();
                }

                var searchResult = new SearchResultDto()
                {
                    Url = result.Url,
                    Keywords = result.Keywords,
                    Ranking = result.Occurrences > 0 ? result.Ranking.Trim() : "0",
                    SearchDate = result.SearchDate.ToString("dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture),
                    Occurrences = result.Occurrences
                };

                return Ok(searchResult);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
        }
    }
}