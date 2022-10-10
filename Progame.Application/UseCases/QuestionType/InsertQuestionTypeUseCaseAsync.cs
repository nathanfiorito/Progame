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
    public class InsertQuestionTypeUseCaseAsync : UseCaseBase, IUseCaseAsync<InsertQuestionTypeRequest, QuestionTypeOutResponse>
    {
        private readonly IQuestionTypeRepository _questionTypeRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public InsertQuestionTypeUseCaseAsync(IQuestionTypeRepository questionTypeRepository,
                                IMapper mapper,
                                IConfiguration configuration)
        {
            _questionTypeRepository = questionTypeRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<QuestionTypeOutResponse> Execute(InsertQuestionTypeRequest request)
        {
            QuestionTypeOutResponse response;
            try
            {
                var questionType = _mapper.Map<Domain.Entities.QuestionType>(request);

                var result = await _questionTypeRepository.CreateAsync(questionType);

                if (result)
                {
                    var msg = "Dado criada com sucesso!";
                    response = new QuestionTypeOutResponse(HttpStatusCode.OK, msg, result);
                }
                else
                {
                    var msg = "Ocorreu um erro ao criar dado! Entre em contato com o adminsitrador do site.";
                    response = new QuestionTypeOutResponse(HttpStatusCode.BadRequest, msg, null);
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
