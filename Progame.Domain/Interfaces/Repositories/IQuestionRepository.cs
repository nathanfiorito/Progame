using Progame.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Progame.Domain.Interfaces.Repositories
{
    public interface IQuestionRepository : IRepositoryBase<Question>
    {
        public Task<List<Question>> GetByModuleId(int moduleId);
    }
}
