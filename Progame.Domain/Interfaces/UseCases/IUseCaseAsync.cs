using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progame.Domain.Interfaces.UseCases
{
    public interface IUseCaseAsync<in TRequest, TReponse>
    {
        Task<TReponse> Execute(TRequest request);
    }
}
