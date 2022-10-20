using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces.Repositories;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models;
using Progame.Domain.Models.Request.Answer;
using Progame.Domain.Models.Response.Answer;
using System.Net;
using System.Threading.Tasks;
using System;

namespace Progame.Application.UseCases.Answer
{
    public class GetAnswerByQuestionIdUseCaseAsync : UseCaseBase, IUseCaseAsync<GetAnswersByQuestionIdRequest, AnswerOutResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IAnswerRepository _answerRepository;

        public GetAnswerByQuestionIdUseCaseAsync(IConfiguration configuration,
                                    IAnswerRepository answerRepository)
        {
            _configuration = configuration;
            _answerRepository = answerRepository;
        }

        public async Task<AnswerOutResponse> Execute(GetAnswersByQuestionIdRequest request)
        {
            try
            {
                var result = await _answerRepository.GetByQuestionId(request.Id);

                if (result != null)
                {
                    var msg = "Data returned with success!";
                    return new AnswerOutResponse(HttpStatusCode.OK, msg, result);
                }
                else
                {
                    var msg = "An error occurred while attempt to find answer! Contact website administrator.";
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
