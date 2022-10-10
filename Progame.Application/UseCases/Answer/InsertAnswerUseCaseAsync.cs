using AutoMapper;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces.Repositories;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models;
using Progame.Domain.Models.Request.Answer;
using Progame.Domain.Models.Request.Category;
using Progame.Domain.Models.Response.Answer;
using Progame.Domain.Models.Response.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Progame.Application.UseCases.Answer
{
    public class InsertAnswerUseCaseAsync : UseCaseBase, IUseCaseAsync<InsertAnswerRequest, AnswerOutResponse>
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly ICompletedModulesRepository _categoryRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public InsertAnswerUseCaseAsync(IAnswerRepository answerRepository,
                                ICompletedModulesRepository categoryRepository,
                                IMapper mapper,
                                IConfiguration configuration)
        {
            _answerRepository = answerRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<AnswerOutResponse> Execute(InsertAnswerRequest request)
        {
            try
            {
                var category = await _categoryRepository.FindByIdAsync(request.QuestionId);

                if(category == null)
                    return new AnswerOutResponse() { StatusCode = HttpStatusCode.NotFound, Mensagem = "Category not found!" };

                var answer = _mapper.Map<Domain.Entities.Answer>(request);

                var result = await _answerRepository.CreateAsync(answer);

                if (result)
                {
                    var msg = "Answer inserted!";
                    return new AnswerOutResponse(HttpStatusCode.OK, msg, result);
                }
                else
                {
                    var msg = "An error occurred while attempt to insert the answer! Contact website administrator.";
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
