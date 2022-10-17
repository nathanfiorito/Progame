using AutoMapper;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces.Repositories;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models;
using Progame.Domain.Models.Request.Module;
using Progame.Domain.Models.Request.Question;
using Progame.Domain.Models.Response.Module;
using Progame.Domain.Models.Response.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Progame.Application.UseCases.Module
{
    public class GetQuestionByIdUseCaseAsync : UseCaseBase, IUseCaseAsync<GetQuestionByIdRequest, QuestionOutResponse>
    {
        private readonly IQuestionRepository _moduleRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public GetQuestionByIdUseCaseAsync(IQuestionRepository moduleRepository,
                                IMapper mapper,
                                IConfiguration configuration)
        {
            _moduleRepository = moduleRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<QuestionOutResponse> Execute(GetQuestionByIdRequest request)
        {
            QuestionOutResponse AnswerOutResponse = new QuestionOutResponse();
            try
            {
                var result = await _moduleRepository.FindByIdAsync(request.Id);

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
