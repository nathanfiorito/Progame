using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Entities;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Interfaces;
using Progame.Domain.Models.Request.Answer;
using Progame.Domain.Models.Response.Answer;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Progame.Application.Utils;
using Progame.Domain.Models.Request.Question;
using Progame.Domain.Models.Response.Question;

namespace Progame.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IUseCaseRespAsync<GetAllQuestionsResponse> _getAllQuestionsUseCaseRespAsync;
        private readonly IUseCaseAsync<GetQuestionByIdRequest, QuestionOutResponse> _getByIdQuestionUseCaseRespAsync;
        private readonly IUseCaseAsync<InsertQuestionRequest, QuestionOutResponse> _insertQuestionUseCaseAsync;
        private readonly IUseCaseAsync<UpdateQuestionRequest, QuestionOutResponse> _updateQuestionUseCaseAsync;
        private readonly IUseCaseAsync<DeleteQuestionRequest, QuestionOutResponse> _deleteQuestionUseCaseAsync;
        private readonly IConfiguration _configuration;

        public QuestionController(IUseCaseRespAsync<GetAllQuestionsResponse> getAllQuestionsUseCaseRespAsync,
                            IUseCaseAsync<GetQuestionByIdRequest, QuestionOutResponse> getByIdQuestionUseCaseRespAsync,
                            IUseCaseAsync<InsertQuestionRequest, QuestionOutResponse> insertQuestionUseCaseAsync,
                            IUseCaseAsync<UpdateQuestionRequest, QuestionOutResponse> updateQuestionUseCaseAsync,
                            IUseCaseAsync<DeleteQuestionRequest, QuestionOutResponse> deleteQuestionUseCaseAsync,
                             IConfiguration configuration)
        {
            _getAllQuestionsUseCaseRespAsync = getAllQuestionsUseCaseRespAsync;
            _getByIdQuestionUseCaseRespAsync = getByIdQuestionUseCaseRespAsync;
            _insertQuestionUseCaseAsync = insertQuestionUseCaseAsync;
            _updateQuestionUseCaseAsync = updateQuestionUseCaseAsync;
            _deleteQuestionUseCaseAsync = deleteQuestionUseCaseAsync;
            _configuration = configuration;
        }

        /// <summary>
        /// Retorna todas as categorias.
        /// </summary>
        /// <response code="200">Categorias retornadas com sucesso.</response>
        /// <response code="204">Categorias retornadas, porém não existe nenhuma.</response>
        /// <response code="500">Ocorreu uma falha ao autenticar o usuário.</response>
        [HttpGet("FindAllAsync")]
        [ProducesResponseType(typeof(List<Question>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> FindAllAsync()
        {
            using (GetAllQuestionsResponse reponse = await _getAllQuestionsUseCaseRespAsync.ExecuteAsync())
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }

        [HttpGet("GetOne")]
        public async Task<IActionResult> GetOne([FromQuery] GetQuestionByIdRequest request)
        {
            using (QuestionOutResponse reponse = await _getByIdQuestionUseCaseRespAsync.Execute(request))
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }

        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateAsync([FromBody] InsertQuestionRequest request)
        {
            using (QuestionOutResponse reponse = await _insertQuestionUseCaseAsync.Execute(request))
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateQuestionRequest request)
        {
            using (QuestionOutResponse reponse = await _updateQuestionUseCaseAsync.Execute(request))
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }

        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteQuestionRequest request)
        {
            using (QuestionOutResponse reponse = await _deleteQuestionUseCaseAsync.Execute(request))
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }
    }
}
