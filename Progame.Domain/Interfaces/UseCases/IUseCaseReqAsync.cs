using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progame.Domain.Interfaces.UseCases
{
    public interface IUseCaseReqAsync<in TRequest>
    {
        Task ExecuteAsync(TRequest request);
    }
}
