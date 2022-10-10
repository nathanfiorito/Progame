using AutoMapper;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces.Repositories;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models;
using Progame.Domain.Models.Request.Answer;
using Progame.Domain.Models.Response.Answer;
using System;
using System.Net;
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
                    var msg = "Data deleted with success!";
                    return new AnswerOutResponse(HttpStatusCode.OK, msg, result);
                }
                else
                {
                    var msg = "An error occurred while attempt to delete the answer! Contact website administrator.";
                    return new AnswerOutResponse(HttpStatusCode.BadRequest, msg, null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
