using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Entities;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Interfaces;
using Progame.Domain.Models.Request.CompletedModules;
using Progame.Domain.Models.Response.CompletedModules;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Progame.Application.Utils;

namespace Progame.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompletedModuleController : ControllerBase
    {
        private readonly IUseCaseRespAsync<GetAllCompletedModulesResponse> _getAllCompletedModulesUseCaseRespAsync;
        private readonly IUseCaseAsync<GetCompletedModuleByIdRequest, CompletedModuleOutResponse> _getByIdCompletedModuleUseCaseRespAsync;
        private readonly IUseCaseAsync<GetCompletedModuleByUserRequest, CompletedModuleOutResponse> _getByUserCompletedModuleUseCaseRespAsync;
        private readonly IUseCaseAsync<InsertCompletedModuleRequest, CompletedModuleOutResponse> _insertCompletedModuleUseCaseAsync;
        private readonly IUseCaseAsync<UpdateCompletedModuleRequest, CompletedModuleOutResponse> _updateCompletedModuleUseCaseAsync;
        private readonly IUseCaseAsync<DeleteCompletedModuleRequest, CompletedModuleOutResponse> _deleteCompletedModuleUseCaseAsync;
        private readonly IConfiguration _configuration;

        public CompletedModuleController(IUseCaseRespAsync<GetAllCompletedModulesResponse> getAllCompletedModulesUseCaseRespAsync,
                            IUseCaseAsync<GetCompletedModuleByIdRequest, CompletedModuleOutResponse> getByIdCompletedModuleUseCaseRespAsync,
                            IUseCaseAsync<GetCompletedModuleByUserRequest, CompletedModuleOutResponse> getByUserCompletedModuleUseCaseRespAsync,
                            IUseCaseAsync<InsertCompletedModuleRequest, CompletedModuleOutResponse> insertCompletedModuleUseCaseAsync,
                            IUseCaseAsync<UpdateCompletedModuleRequest, CompletedModuleOutResponse> updateCompletedModuleUseCaseAsync,
                            IUseCaseAsync<DeleteCompletedModuleRequest, CompletedModuleOutResponse> deleteCompletedModuleUseCaseAsync,
                             IConfiguration configuration)
        {
            _getAllCompletedModulesUseCaseRespAsync = getAllCompletedModulesUseCaseRespAsync;
            _getByIdCompletedModuleUseCaseRespAsync = getByIdCompletedModuleUseCaseRespAsync;
            _getByUserCompletedModuleUseCaseRespAsync = getByUserCompletedModuleUseCaseRespAsync;
            _insertCompletedModuleUseCaseAsync = insertCompletedModuleUseCaseAsync;
            _updateCompletedModuleUseCaseAsync = updateCompletedModuleUseCaseAsync;
            _deleteCompletedModuleUseCaseAsync = deleteCompletedModuleUseCaseAsync;
            _configuration = configuration;
        }

        /// <summary>
        /// Retorna todas as categorias.
        /// </summary>
        /// <response code="200">Categorias retornadas com sucesso.</response>
        /// <response code="204">Categorias retornadas, porém não existe nenhuma.</response>
        /// <response code="500">Ocorreu uma falha ao autenticar o usuário.</response>
        [HttpGet("FindAllAsync")]
        [ProducesResponseType(typeof(List<CompletedModules>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> FindAllAsync()
        {
            using (GetAllCompletedModulesResponse reponse = await _getAllCompletedModulesUseCaseRespAsync.ExecuteAsync())
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }

        [HttpGet("GetOne")]
        public async Task<IActionResult> GetOne([FromQuery] GetCompletedModuleByIdRequest request)
        {
            using (CompletedModuleOutResponse reponse = await _getByIdCompletedModuleUseCaseRespAsync.Execute(request))
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }

        [HttpGet("GetByUser")]
        public async Task<IActionResult> GetByUser([FromQuery] GetCompletedModuleByUserRequest request)
        {
            using (CompletedModuleOutResponse reponse = await _getByUserCompletedModuleUseCaseRespAsync.Execute(request))
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }

        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateAsync([FromBody] InsertCompletedModuleRequest request)
        {
            using (CompletedModuleOutResponse reponse = await _insertCompletedModuleUseCaseAsync.Execute(request))
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCompletedModuleRequest request)
        {
            using (CompletedModuleOutResponse reponse = await _updateCompletedModuleUseCaseAsync.Execute(request))
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }

        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteCompletedModuleRequest request)
        {
            using (CompletedModuleOutResponse reponse = await _deleteCompletedModuleUseCaseAsync.Execute(request))
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }
    }
}
