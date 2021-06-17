using Microsoft.EntityFrameworkCore;
using WebScrapper.Data.Models;

namespace WebScrapper.Data.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public AppDbContext() { }
        public virtual DbSet<SearchResult> SearchResults { get; set; }
    }
}
