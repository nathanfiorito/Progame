using AutoMapper;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces.Repositories;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models;
using Progame.Domain.Models.Request.Module;
using Progame.Domain.Models.Request.Question;
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
    public class DeleteQuestionUseCaseAsync : UseCaseBase, IUseCaseAsync<DeleteQuestionRequest, QuestionOutResponse>
    {
        private readonly IQuestionRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public DeleteQuestionUseCaseAsync(IQuestionRepository repository,
                                IMapper mapper,
                                IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<QuestionOutResponse> Execute(DeleteQuestionRequest request)
        {
            QuestionOutResponse response = new QuestionOutResponse();
            try
            {
                var module = await _repository.FindByIdAsync(request.Id);

                if (module == null)
                    return new QuestionOutResponse() { StatusCode = HttpStatusCode.NoContent, Mensagem = "Module not found!" };

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
