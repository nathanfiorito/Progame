using AutoMapper;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces.Repositories;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models;
using Progame.Domain.Models.Request.Module;
using Progame.Domain.Models.Request.Question;
using Progame.Domain.Models.Response.Answer;
using Progame.Domain.Models.Response.Module;
using Progame.Domain.Models.Response.Question;
using Progame.Infrastructure.Data.Repositories;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Progame.Application.UseCases.Module
{
    public class UpdateQuestionsUseCaseAsync : UseCaseBase, IUseCaseAsync<UpdateQuestionRequest, QuestionOutResponse>
    {
        private readonly IQuestionRepository _moduleRepository;
        private readonly IQuestionTypeRepository _questionTypeRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UpdateQuestionsUseCaseAsync(IQuestionRepository moduleRepository,
                                IQuestionTypeRepository questionTypeRepository,
                                IAnswerRepository answerRepository,
                                IMapper mapper,
                                IConfiguration configuration)
        {
            _moduleRepository = moduleRepository;
            _questionTypeRepository = questionTypeRepository;
            _answerRepository = answerRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<QuestionOutResponse> Execute(UpdateQuestionRequest request)
        {
            QuestionOutResponse response = new QuestionOutResponse();
            try
            {
                var module = await _moduleRepository.FindByIdAsync(request.Id);

                if (module == null)
                    return new QuestionOutResponse() { StatusCode = HttpStatusCode.NotFound, Mensagem = "Module not found!" };

                var questionType = await _questionTypeRepository.FindByIdAsync(request.QuestionTypeId);

                if (questionType == null)
                    return new QuestionOutResponse() { StatusCode = HttpStatusCode.NotFound, Mensagem = "Question Type not found!" };

                if(request.CorrectAnswerId != 0)
                {
                    var answer = await _answerRepository.FindByIdAsync(request.CorrectAnswerId);

                    if(answer == null)
                        return new QuestionOutResponse() { StatusCode = HttpStatusCode.NotFound, Mensagem = "Answer not found!" };
                }

                module = _mapper.Map<Domain.Entities.Question>(module);

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
