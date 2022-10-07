using AutoMapper;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces.Repositories;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models.Request.CompletedModules;
using Progame.Domain.Models.Response.CompletedModules;
using Progame.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Progame.Infrastructure.Data.Repositories;
using Progame.Infrastructure.Repositories;

namespace Progame.Application.UseCases.CompletedModules
{
    public class InsertCompletedModuleUseCaseAsync : UseCaseBase, IUseCaseAsync<InsertCompletedModuleRequest, CompletedModuleOutResponse>
    {
        private readonly ICompletedModulesRepository _completedModulesRepository;
        private readonly IModuleRepository _moduleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public InsertCompletedModuleUseCaseAsync(
            ICompletedModulesRepository completedModulesRepository,
            IModuleRepository moduleRepository,
            IUserRepository userRepository,
            IMapper mapper,
            IConfiguration configuration
            )
        {
            _completedModulesRepository = completedModulesRepository;
            _moduleRepository = moduleRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<CompletedModuleOutResponse> Execute(InsertCompletedModuleRequest request)
        {
            CompletedModuleOutResponse response = new CompletedModuleOutResponse();
            try
            {
                var user = await _userRepository.FindByIdAsync(request.UserId);

                if (user == null)
                    return new CompletedModuleOutResponse() { StatusCode = HttpStatusCode.Unauthorized, Mensagem = "User not found!" };

                var module = await _moduleRepository.FindByIdAsync(request.ModuleId);

                if (module == null)
                    return new CompletedModuleOutResponse() { StatusCode = HttpStatusCode.Unauthorized, Mensagem = "Module not found!" };

                var CompletedModules = _mapper.Map<Domain.Entities.CompletedModules>(request);

                var result = await _completedModulesRepository.CreateAsync(CompletedModules);

                if (result)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Data = result;
                    response.Mensagem = "Dado Inserido com sucesso!";
                }
                else
                {
                    response.StatusCode = HttpStatusCode.NoContent;
                    response.Data = null;
                    response.Mensagem = "Ocorreu um erro ao inserir dado! Entre em contato com o adminsitrador do site.";
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
