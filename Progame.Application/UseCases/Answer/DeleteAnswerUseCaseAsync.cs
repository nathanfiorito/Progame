using AutoMapper;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces.Repositories;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models;
using Progame.Domain.Models.Request.Answer;
using Progame.Domain.Models.Response.Answer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Progame.Application.UseCases.Answer
{
    public class DeleteAnswerUseCaseAsync : UseCaseBase, IUseCaseAsync<DeleteAnswerRequest, AnswerOutResponse>
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public DeleteAnswerUseCaseAsync(IAnswerRepository answerRepository,
                                IMapper mapper,
                                IConfiguration configuration)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<AnswerOutResponse> Execute(DeleteAnswerRequest request)
        {
            AnswerOutResponse response = new AnswerOutResponse();
            try
            {
                var Answer = await _answerRepository.FindByIdAsync(request.Id);

                if (Answer == null)
                    return new AnswerOutResponse() { StatusCode = HttpStatusCode.NoContent, Mensagem = "Answer not found!" };

                var result = await _answerRepository.DeleteAsync(Answer.Id);

                if (result)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Data = result;
                    response.Mensagem = "Resposta deletada com sucesso!";
                }
                else
                {
                    response.StatusCode = HttpStatusCode.NoContent;
                    response.Data = null;
                    response.Mensagem = "Ocorreu um erro ao deletar a resposta! Entre em contato com o adminsitrador do site.";
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
