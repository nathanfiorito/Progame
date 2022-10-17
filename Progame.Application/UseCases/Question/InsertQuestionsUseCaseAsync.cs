using AutoMapper;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces.Repositories;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models;
using Progame.Domain.Models.Request.Answer;
using Progame.Domain.Models.Request.Category;
using Progame.Domain.Models.Request.Module;
using Progame.Domain.Models.Request.Question;
using Progame.Domain.Models.Response.Answer;
using Progame.Domain.Models.Response.Category;
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
    public class InsertQuestionsUseCaseAsync : UseCaseBase, IUseCaseAsync<InsertQuestionRequest, QuestionOutResponse>
    {
        private readonly IQuestionRepository _moduleRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public InsertQuestionsUseCaseAsync(IQuestionRepository moduleRepository,
                                IMapper mapper,
                                IConfiguration configuration)
        {
            _moduleRepository = moduleRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<QuestionOutResponse> Execute(InsertQuestionRequest request)
        {
            QuestionOutResponse response = new QuestionOutResponse();
            try
            {
                var questionType = _mapper.Map<Domain.Entities.Question>(request);
                questionType.CorrectAnswerId = null;

                var result = await _moduleRepository.CreateAsync(questionType);

                if (result)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Data = result;
                    response.Mensagem = "Resposta criada com sucesso!";
                }
                else
                {
                    response.StatusCode = HttpStatusCode.NoContent;
                    response.Data = null;
                    response.Mensagem = "Ocorreu um erro ao criar a resposta! Entre em contato com o adminsitrador do site.";
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
