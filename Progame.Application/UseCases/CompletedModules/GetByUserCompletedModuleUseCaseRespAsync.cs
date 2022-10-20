using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces.Repositories;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models;
using Progame.Domain.Models.Request.CompletedModules;
using Progame.Domain.Models.Response.CompletedModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Progame.Application.UseCases.CompletedModules
{
    public class GetByUserCompletedModuleUseCaseRespAsync : UseCaseBase, IUseCaseAsync<GetCompletedModuleByUserRequest, CompletedModuleOutResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly ICompletedModulesRepository _completedModuleRepository;

        public GetByUserCompletedModuleUseCaseRespAsync(IConfiguration configuration,
                                    ICompletedModulesRepository completedModuleRepository)
        {
            _configuration = configuration;
            _completedModuleRepository = completedModuleRepository;
        }

        public async Task<CompletedModuleOutResponse> Execute(GetCompletedModuleByUserRequest request)
        {
            CompletedModuleOutResponse CompletedModuleOutResponse = new CompletedModuleOutResponse();
            try
            {
                var result = await _completedModuleRepository.FindByUserIdAsync(request.Id);

                if (result != null)
                {
                    CompletedModuleOutResponse.StatusCode = HttpStatusCode.OK;
                    CompletedModuleOutResponse.Data = result;
                    CompletedModuleOutResponse.Mensagem = "Dados retornados com sucesso!";
                }
                else
                {
                    CompletedModuleOutResponse.StatusCode = HttpStatusCode.NoContent;
                    CompletedModuleOutResponse.Data = null;
                    CompletedModuleOutResponse.Mensagem = "Não foi encontrado nenhum resultado com os parametros informados.";
                }
                return CompletedModuleOutResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
