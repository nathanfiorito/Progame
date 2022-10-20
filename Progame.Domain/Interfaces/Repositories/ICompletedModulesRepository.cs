using Progame.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Progame.Domain.Interfaces.Repositories
{
    public interface ICompletedModulesRepository : IRepositoryBase<CompletedModules>
    {
        public Task<List<CompletedModules>> FindByUserIdAsync(int userId);
    }
}
