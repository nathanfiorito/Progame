using Progame.Domain.Entities;
using Progame.Domain.Models.Response.Module;
using System.Threading.Tasks;

namespace Progame.Domain.Interfaces.Repositories
{
    public interface IModuleRepository : IRepositoryBase<Module>
    {
        public Task<Module> GetModuleWithQuestion(int moduleId);
    }
}
