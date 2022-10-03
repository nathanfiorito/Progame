using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progame.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity> FindByIdAsync(int id);
        Task<IQueryable<TEntity>> FindAllAsync();
        Task<bool> CreateAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(TEntity entity);
    }
}
