using AutoMapper;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces.Repositories;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models.Request.Category;
using Progame.Domain.Models.Response.Category;
using Progame.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Progame.Domain.Models.Request.CompletedModules;
using Progame.Domain.Models.Response.CompletedModules;

namespace Progame.Application.UseCases.CompletedModules
{
    public class DeleteCompletedModuleUseCaseAsync : UseCaseBase, IUseCaseAsync<DeleteCompletedModuleRequest, CompletedModuleOutResponse>
    {
        private readonly ICompletedModulesRepository _completedModuleRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public DeleteCompletedModuleUseCaseAsync(ICompletedModulesRepository completedModuleRepository,
                                IMapper mapper,
                                IConfiguration configuration)
        {
            _completedModuleRepository = completedModuleRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<CompletedModuleOutResponse> Execute(DeleteCompletedModuleRequest request)
        {
            CompletedModuleOutResponse response = new CompletedModuleOutResponse();
            try
            {
                var category = await _completedModuleRepository.FindByIdAsync(request.Id);

                if (category == null)
                    return new CompletedModuleOutResponse() { StatusCode = HttpStatusCode.NoContent, Mensagem = "Category not found!" };

                var result = await _completedModuleRepository.DeleteAsync(category.Id);

                if (result)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Data = result;
                    response.Mensagem = "Dado deletada com sucesso!";
                }
                else
                {
                    response.StatusCode = HttpStatusCode.NoContent;
                    response.Data = null;
                    response.Mensagem = "Ocorreu um erro ao deletar a dado! Entre em contato com o adminsitrador do site.";
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
