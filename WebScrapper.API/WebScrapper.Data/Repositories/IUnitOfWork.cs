using System;
using System.Threading.Tasks;

namespace WebScrapper.Data.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ISearchRepository SearcheResults { get; }

        Task<int> CompleteAsync();
    }
}
