using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models.Request.Module;
using Progame.Domain.Models.Response.Module;
using Progame.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progame.Domain.Models.Request.QuestionType;
using Progame.Domain.Models.Response.QuestionType;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces.Repositories;
using System.Net;

namespace Progame.Application.UseCases.QuestionType
{
    public class GetQuestionTypeByIdUseCaseRespAsync : UseCaseBase, IUseCaseAsync<GetQuestionTypeByIdRequest, QuestionTypeOutResponse>
    {
        private readonly IQuestionTypeRepository _questionTypeRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public GetQuestionTypeByIdUseCaseRespAsync(IQuestionTypeRepository questionTypeRepository,
                                IMapper mapper,
                                IConfiguration configuration)
        {
            _questionTypeRepository = questionTypeRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<QuestionTypeOutResponse> Execute(GetQuestionTypeByIdRequest request)
        {
            QuestionTypeOutResponse AnswerOutResponse = new QuestionTypeOutResponse();
            try
            {
                var result = await _questionTypeRepository.FindByIdAsync(request.Id);

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
