using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models.Request.Module;
using Progame.Domain.Models.Response.Module;
using Progame.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progame.Domain.Models.Request.QuestionType;
using Progame.Domain.Models.Response.QuestionType;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces.Repositories;
using System.Net;

namespace Progame.Application.UseCases.QuestionType
{
    public class UpdateQuestionTypeUseCaseAsync : UseCaseBase, IUseCaseAsync<UpdateQuestionTypeRequest, QuestionTypeOutResponse>
    {
        private readonly IQuestionTypeRepository _questionTypeRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UpdateQuestionTypeUseCaseAsync(IQuestionTypeRepository questionTypeRepository,
                                IMapper mapper,
                                IConfiguration configuration)
        {
            _questionTypeRepository = questionTypeRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<QuestionTypeOutResponse> Execute(UpdateQuestionTypeRequest request)
        {
            QuestionTypeOutResponse response = new QuestionTypeOutResponse();
            try
            {
                var questionType = await _questionTypeRepository.FindByIdAsync(request.Id);

                if (questionType == null)
                    return new QuestionTypeOutResponse() { StatusCode = HttpStatusCode.Unauthorized, Mensagem = "QuestionType not found!" };

                questionType.Type = request.Type;

                var result = await _questionTypeRepository.UpdateAsync(questionType);

                if (result)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Data = result;
                    response.Mensagem = "Dado atualizada com sucesso!";
                }
                else
                {
                    response.StatusCode = HttpStatusCode.NoContent;
                    response.Data = null;
                    response.Mensagem = "Ocorreu um erro ao atualizar dado! Entre em contato com o adminsitrador do site.";
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
