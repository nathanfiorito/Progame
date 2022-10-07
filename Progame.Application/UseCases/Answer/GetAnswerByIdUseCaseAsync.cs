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
    public class GetAnswerByIdUseCaseAsync : UseCaseBase, IUseCaseAsync<GetAnswerByIdRequest, AnswerOutResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IAnswerRepository _answerRepository;

        public GetAnswerByIdUseCaseAsync(IConfiguration configuration,
                                    IAnswerRepository answerRepository)
        {
            _configuration = configuration;
            _answerRepository = answerRepository;
        }

        public async Task<AnswerOutResponse> Execute(GetAnswerByIdRequest request)
        {
            AnswerOutResponse AnswerOutResponse = new AnswerOutResponse();
            try
            {
                var result = await _answerRepository.FindByIdAsync(request.Id);

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
