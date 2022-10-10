using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces.Repositories;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models;
using Progame.Domain.Models.Response.Answer;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Progame.Application.UseCases.Answer
{
    public class GetAllAnswersUseCaseRespAsync : UseCaseBase, IUseCaseRespAsync<GetAllAnswersResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IAnswerRepository _answerRepository;

        public GetAllAnswersUseCaseRespAsync(IConfiguration configuration,
                                        IAnswerRepository answerRepository)
        {
            _configuration = configuration;
            _answerRepository = answerRepository;
        }

        public async Task<GetAllAnswersResponse> ExecuteAsync()
        {
            try
            {
                var result = await _answerRepository.FindAllAsync();

                if (result.Any())
                {
                    var msg = "Data returned with success!";
                    return new GetAllAnswersResponse(HttpStatusCode.OK, msg, result);
                }
                else
                {
                    var msg = "An error occurred while attempt to find answers! Contact website administrator.";
                    return new GetAllAnswersResponse(HttpStatusCode.BadRequest, msg, null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
