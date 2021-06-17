using System.Threading.Tasks;
using WebScrapper.Data.Models;

namespace WebScrapper.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseModel
    {
        Task<TEntity> GetAsync(int id);
        Task AddAsync(TEntity entity);
    }
}
