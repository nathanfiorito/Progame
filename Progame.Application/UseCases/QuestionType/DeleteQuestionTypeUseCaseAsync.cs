using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models;
using System;
using System.Threading.Tasks;
using Progame.Domain.Models.Request.QuestionType;
using Progame.Domain.Models.Response.QuestionType;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces.Repositories;
using System.Net;

namespace Progame.Application.UseCases.QuestionType
{
    public class DeleteQuestionTypeUseCaseAsync : UseCaseBase, IUseCaseAsync<DeleteQuestionTypeRequest, QuestionTypeOutResponse>
    {
        private readonly IQuestionTypeRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public DeleteQuestionTypeUseCaseAsync(IQuestionTypeRepository repository,
                                IMapper mapper,
                                IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<QuestionTypeOutResponse> Execute(DeleteQuestionTypeRequest request)
        {
            QuestionTypeOutResponse response = new QuestionTypeOutResponse();
            try
            {
                var module = await _repository.FindByIdAsync(request.Id);

                if (module == null)
                    return new QuestionTypeOutResponse() { StatusCode = HttpStatusCode.NoContent, Mensagem = "Module not found!" };

                var result = await _repository.DeleteAsync(module.Id);

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
