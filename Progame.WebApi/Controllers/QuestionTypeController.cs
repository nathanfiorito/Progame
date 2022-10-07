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
using Progame.Domain.Models.Request.QuestionType;
using Progame.Domain.Models.Response.QuestionType;

namespace Progame.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionTypeController : ControllerBase
    {
        private readonly IUseCaseRespAsync<GetAllQuestionTypeResponse> _getAllQuestionTypesUseCaseRespAsync;
        private readonly IUseCaseAsync<GetQuestionTypeByIdRequest, QuestionTypeOutResponse> _getQuestionTypeByIdUseCaseRespAsync;
        private readonly IUseCaseAsync<InsertQuestionTypeRequest, QuestionTypeOutResponse> _insertQuestionTypeUseCaseAsync;
        private readonly IUseCaseAsync<UpdateQuestionTypeRequest, QuestionTypeOutResponse> _updateQuestionTypeUseCaseAsync;
        private readonly IUseCaseAsync<DeleteQuestionTypeRequest, QuestionTypeOutResponse> _deleteQuestionTypeUseCaseAsync;
        private readonly IConfiguration _configuration;

        public QuestionTypeController(IUseCaseRespAsync<GetAllQuestionTypeResponse> getAllQuestionTypesUseCaseRespAsync,
                            IUseCaseAsync<GetQuestionTypeByIdRequest, QuestionTypeOutResponse> getQuestionTypeByIdUseCaseRespAsync,
                            IUseCaseAsync<InsertQuestionTypeRequest, QuestionTypeOutResponse> insertQuestionTypeUseCaseAsync,
                            IUseCaseAsync<UpdateQuestionTypeRequest, QuestionTypeOutResponse> updateQuestionTypeUseCaseAsync,
                            IUseCaseAsync<DeleteQuestionTypeRequest, QuestionTypeOutResponse> deleteQuestionTypeUseCaseAsync,
                            IConfiguration configuration)
        {
            _getAllQuestionTypesUseCaseRespAsync = getAllQuestionTypesUseCaseRespAsync;
            _getQuestionTypeByIdUseCaseRespAsync = getQuestionTypeByIdUseCaseRespAsync;
            _insertQuestionTypeUseCaseAsync = insertQuestionTypeUseCaseAsync;
            _updateQuestionTypeUseCaseAsync = updateQuestionTypeUseCaseAsync;
            _deleteQuestionTypeUseCaseAsync = deleteQuestionTypeUseCaseAsync;
            _configuration = configuration;
        }

        /// <summary>
        /// Retorna todas as categorias.
        /// </summary>
        /// <response code="200">Categorias retornadas com sucesso.</response>
        /// <response code="204">Categorias retornadas, porém não existe nenhuma.</response>
        /// <response code="500">Ocorreu uma falha ao autenticar o usuário.</response>
        [HttpGet("FindAllAsync")]
        [ProducesResponseType(typeof(List<Answer>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> FindAllAsync()
        {
            using (GetAllQuestionTypeResponse reponse = await _getAllQuestionTypesUseCaseRespAsync.ExecuteAsync())
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }

        [HttpGet("GetOne")]
        public async Task<IActionResult> GetOne([FromQuery] GetQuestionTypeByIdRequest request)
        {
            using (QuestionTypeOutResponse reponse = await _getQuestionTypeByIdUseCaseRespAsync.Execute(request))
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }

        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateAsync([FromBody] InsertQuestionTypeRequest request)
        {
            using (QuestionTypeOutResponse reponse = await _insertQuestionTypeUseCaseAsync.Execute(request))
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateQuestionTypeRequest request)
        {
            using (QuestionTypeOutResponse reponse = await _updateQuestionTypeUseCaseAsync.Execute(request))
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }

        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteQuestionTypeRequest request)
        {
            using (QuestionTypeOutResponse reponse = await _deleteQuestionTypeUseCaseAsync.Execute(request))
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }
    }
}
