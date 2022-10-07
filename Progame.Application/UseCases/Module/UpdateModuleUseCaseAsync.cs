using AutoMapper;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces.Repositories;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models;
using Progame.Domain.Models.Request.Module;
using Progame.Domain.Models.Response.Answer;
using Progame.Domain.Models.Response.Module;
using Progame.Infrastructure.Data.Repositories;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Progame.Application.UseCases.Module
{
    public class UpdateModuleUseCaseAsync : UseCaseBase, IUseCaseAsync<UpdateModuleRequest, ModuleOutResponse>
    {
        private readonly IModuleRepository _moduleRepository;
        private readonly ICompletedModulesRepository _categoryRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UpdateModuleUseCaseAsync(IModuleRepository moduleRepository,
                                ICompletedModulesRepository categoryRepository,
                                IMapper mapper,
                                IConfiguration configuration)
        {
            _moduleRepository = moduleRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<ModuleOutResponse> Execute(UpdateModuleRequest request)
        {
            ModuleOutResponse response = new ModuleOutResponse();
            try
            {
                var module = await _moduleRepository.FindByIdAsync(request.Id);

                if (module == null)
                    return new ModuleOutResponse() { StatusCode = HttpStatusCode.Unauthorized, Mensagem = "Answer not found!" };

                var category = await _categoryRepository.FindByIdAsync(request.CategoryId);

                if (category == null)
                    return new ModuleOutResponse() { StatusCode = HttpStatusCode.NotFound, Mensagem = "Category not found!" };

                module.ModuleName = request.ModuleName;
                module.CategoryId = request.CategoryId;
                module.Resume = request.Resume;
                module.SupportText = request.SupportText;
                module.ImgUrl = request.ImgUrl;
                module.UpdatedAt = DateTime.Now;

                var result = await _moduleRepository.UpdateAsync(module);

                if (result)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Data = result;
                    response.Mensagem = "Resposta atualizada com sucesso!";
                }
                else
                {
                    response.StatusCode = HttpStatusCode.NoContent;
                    response.Data = null;
                    response.Mensagem = "Ocorreu um erro ao atualizar a Resposta! Entre em contato com o adminsitrador do site.";
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
