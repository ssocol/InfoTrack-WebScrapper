using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebScrapper.Data.Data;

namespace WebScrapper.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            SearcheResults = new SearchRepository(context);
        }

        public ISearchRepository SearcheResults { get; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
