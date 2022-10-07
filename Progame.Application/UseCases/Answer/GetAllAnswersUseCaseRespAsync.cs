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
                GetAllAnswersResponse AnswerOutResponse = new GetAllAnswersResponse();

                var result = await _answerRepository.FindAllAsync();

                if (result.Count() > 0)
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
