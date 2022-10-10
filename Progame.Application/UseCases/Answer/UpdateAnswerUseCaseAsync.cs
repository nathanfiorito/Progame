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
    public class UpdateAnswerUseCaseAsync : UseCaseBase, IUseCaseAsync<UpdateAnswerRequest, AnswerOutResponse>
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UpdateAnswerUseCaseAsync(IAnswerRepository answerRepository,
                                IMapper mapper,
                                IConfiguration configuration)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<AnswerOutResponse> Execute(UpdateAnswerRequest request)
        {
            try
            {
                var answer = await _answerRepository.FindByIdAsync(request.Id);

                if (answer == null)
                    return new AnswerOutResponse(HttpStatusCode.NotFound, "Answer not found.", null);

                answer = _mapper.Map<Domain.Entities.Answer>(request);

                var result = await _answerRepository.UpdateAsync(answer);

                if (result)
                {
                    var msg = "Answer updated!";
                    return new AnswerOutResponse(HttpStatusCode.OK, msg, result);
                }
                else
                {
                    var msg = "An error occurred while attempt to update the answer! Contact website administrator.";
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
