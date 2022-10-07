using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces.Repositories;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models;
using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Progame.Domain.Models.Response.CompletedModules;

namespace Progame.Application.UseCases.CompletedModules
{
    public class GetAllCompletedModulesUseCaseRespAsync : UseCaseBase, IUseCaseRespAsync<GetAllCompletedModulesResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly ICompletedModulesRepository _completedModuleRepository;

        public GetAllCompletedModulesUseCaseRespAsync(IConfiguration configuration,
                                        ICompletedModulesRepository completedModuleRepository)
        {
            _configuration = configuration;
            _completedModuleRepository = completedModuleRepository;
        }

        public async Task<GetAllCompletedModulesResponse> ExecuteAsync()
        {
            try
            {
                GetAllCompletedModulesResponse completedModuleOutResponse = new GetAllCompletedModulesResponse();

                var result = await _completedModuleRepository.FindAllAsync();

                if (result.Count() > 0)
                {
                    completedModuleOutResponse.StatusCode = HttpStatusCode.OK;
                    completedModuleOutResponse.Data = result;
                    completedModuleOutResponse.Mensagem = "Dados retornados com sucesso!";
                }
                else
                {
                    completedModuleOutResponse.StatusCode = HttpStatusCode.NoContent;
                    completedModuleOutResponse.Data = null;
                    completedModuleOutResponse.Mensagem = "Não foi encontrado nenhum resultado com os parametros informados.";
                }
                return completedModuleOutResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
