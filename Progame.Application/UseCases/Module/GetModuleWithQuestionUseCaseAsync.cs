using AutoMapper;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces.Repositories;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models.Request.Module;
using Progame.Domain.Models.Response.Module;
using Progame.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Progame.Infrastructure.Data.Repositories;
using Progame.Domain.Models.Request.Question;

namespace Progame.Application.UseCases.Module
{
    public class GetModuleWithQuestionUseCaseAsync : UseCaseBase, IUseCaseAsync<GetQuestionByModuleIdRequest, ModuleOutResponse>
    {
        private readonly IModuleRepository _moduleRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public GetModuleWithQuestionUseCaseAsync(IModuleRepository moduleRepository,
            IQuestionRepository questionRepository,
            IMapper mapper,
            IConfiguration configuration)
        {
            _moduleRepository = moduleRepository;
            _questionRepository = questionRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<ModuleOutResponse> Execute(GetQuestionByModuleIdRequest request)
        {
            ModuleOutResponse AnswerOutResponse = new ModuleOutResponse();
            try
            {
                ModuleWithQuestionResponse result = new ModuleWithQuestionResponse();

                result.Module = (await _moduleRepository.FindByIdAsync(request.Id));
                result.Questions = (await _questionRepository.GetByModuleId(request.Id));

                if (result != null)
                {
                    AnswerOutResponse.StatusCode = HttpStatusCode.OK;
                    AnswerOutResponse.Data = result;
                    AnswerOutResponse.Mensagem = "Dados retornados com sucesso!";
                }
                else
                {
                    AnswerOutResponse.StatusCode = HttpStatusCode.NoContent;
                    AnswerOutResponse.Data = null;
                    AnswerOutResponse.Mensagem = "Não foi encontrado nenhum resultado com os parametros informados.";
                }
                return AnswerOutResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
