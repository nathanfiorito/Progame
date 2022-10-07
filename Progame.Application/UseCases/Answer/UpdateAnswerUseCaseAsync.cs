using AutoMapper;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces.Repositories;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models;
using Progame.Domain.Models.Request.Answer;
using Progame.Domain.Models.Request.Category;
using Progame.Domain.Models.Response.Answer;
using Progame.Domain.Models.Response.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Progame.Application.UseCases.Answer
{
    public class UpdateAnswerUseCaseAsync : UseCaseBase, IUseCaseAsync<UpdateAnswerRequest, AnswerOutResponse>
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UpdateAnswerUseCaseAsync(IAnswerRepository answerRepository,
                                IMapper mapper,
                                IConfiguration configuration)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<AnswerOutResponse> Execute(UpdateAnswerRequest request)
        {
            AnswerOutResponse response = new AnswerOutResponse();
            try
            {
                var answer = await _answerRepository.FindByIdAsync(request.Id);

                if (answer == null)
                    return new AnswerOutResponse() { StatusCode = HttpStatusCode.Unauthorized, Mensagem = "Answer not found!" };

                answer.AnswerText = request.AnswerText;
                answer.QuestionId = request.QuestionId;
                answer.UpdatedAt = DateTime.Now;

                var result = await _answerRepository.UpdateAsync(answer);

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
