using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progame.Domain.Interfaces.UseCases
{
    public interface IUseCaseAsyncParameter<in TRequest, TResponse>
    {
        Task<TResponse> ExecuteAsync(TRequest request, int parameter);
    }
}
