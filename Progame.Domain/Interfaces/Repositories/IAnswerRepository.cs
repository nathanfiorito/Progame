using Progame.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Progame.Domain.Interfaces.Repositories
{
    public interface IAnswerRepository : IRepositoryBase<Answer>
    {
        public Task<List<Answer>> GetByQuestionId(int questionId);
    }
}
