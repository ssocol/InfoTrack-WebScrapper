using System.Collections.Generic;
using System.Threading.Tasks;
using WebScrapper.Data.Models;

namespace WebScrapper.Domain.Services
{
    public interface ISearchService
    {
        Task<IEnumerable<SearchResult>> GetHistory();
        Task<SearchResult> Search(string companyName, string searchTerms);
    }
}