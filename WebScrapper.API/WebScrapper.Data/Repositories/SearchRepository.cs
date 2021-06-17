using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebScrapper.Data.Models;
using WebScrapper.Data.Data;

namespace WebScrapper.Data.Repositories
{
    public class SearchRepository : Repository<SearchResult>, ISearchRepository
    {
        public SearchRepository(AppDbContext context)
            : base(context) { }

        public AppDbContext DbContext
        {
            get { return Context as AppDbContext; }
        }

        public async Task<IEnumerable<SearchResult>> GetSearchHistoryAsync()
        {
            var result = await DbContext.SearchResults
                .OrderByDescending(s => s.SearchDate)
                .Take(10)
                .ToListAsync();

            return result;
        }
    }
}