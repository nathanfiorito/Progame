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

namespace Progame.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IUseCaseRespAsync<GetAllAnswersResponse> _getAllAnswersUseCaseRespAsync;
        private readonly IUseCaseAsync<GetAnswerByIdRequest, AnswerOutResponse> _getByIdAnswerUseCaseRespAsync;
        private readonly IUseCaseAsync<InsertAnswerRequest, AnswerOutResponse> _insertAnswerUseCaseAsync;
        private readonly IUseCaseAsync<UpdateAnswerRequest, AnswerOutResponse> _updateAnswerUseCaseAsync;
        private readonly IUseCaseAsync<DeleteAnswerRequest, AnswerOutResponse> _deleteAnswerUseCaseAsync;
        private readonly IConfiguration _configuration;

        public AnswerController(IUseCaseRespAsync<GetAllAnswersResponse> getAllAnswersUseCaseRespAsync,
                            IUseCaseAsync<GetAnswerByIdRequest, AnswerOutResponse> getByIdAnswerUseCaseRespAsync,
                            IUseCaseAsync<InsertAnswerRequest, AnswerOutResponse> insertAnswerUseCaseAsync,
                            IUseCaseAsync<UpdateAnswerRequest, AnswerOutResponse> updateAnswerUseCaseAsync,
                            IUseCaseAsync<DeleteAnswerRequest, AnswerOutResponse> deleteAnswerUseCaseAsync,
                             IConfiguration configuration)
        {
            _getAllAnswersUseCaseRespAsync = getAllAnswersUseCaseRespAsync;
            _getByIdAnswerUseCaseRespAsync = getByIdAnswerUseCaseRespAsync;
            _insertAnswerUseCaseAsync = insertAnswerUseCaseAsync;
            _updateAnswerUseCaseAsync = updateAnswerUseCaseAsync;
            _deleteAnswerUseCaseAsync = deleteAnswerUseCaseAsync;
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
            using (GetAllAnswersResponse reponse = await _getAllAnswersUseCaseRespAsync.ExecuteAsync())
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }

        [HttpGet("GetOne")]
        public async Task<IActionResult> GetOne([FromQuery] GetAnswerByIdRequest request)
        {
            using (AnswerOutResponse reponse = await _getByIdAnswerUseCaseRespAsync.Execute(request))
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }

        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateAsync([FromBody] InsertAnswerRequest request)
        {
            using (AnswerOutResponse reponse = await _insertAnswerUseCaseAsync.Execute(request))
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateAnswerRequest request)
        {
            using (AnswerOutResponse reponse = await _updateAnswerUseCaseAsync.Execute(request))
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }

        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteAnswerRequest request)
        {
            using (AnswerOutResponse reponse = await _deleteAnswerUseCaseAsync.Execute(request))
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }
    }
}
