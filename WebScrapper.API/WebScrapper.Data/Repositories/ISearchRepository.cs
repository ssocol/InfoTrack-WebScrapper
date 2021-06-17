using System.Collections.Generic;
using System.Threading.Tasks;
using WebScrapper.Data.Models;

namespace WebScrapper.Data.Repositories
{
    public interface ISearchRepository : IRepository<SearchResult>
    {
        Task<IEnumerable<SearchResult>> GetSearchHistoryAsync();
    }
}
