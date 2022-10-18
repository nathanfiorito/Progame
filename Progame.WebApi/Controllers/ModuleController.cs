using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Entities;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Interfaces;
using Progame.Domain.Models.Request.Module;
using Progame.Domain.Models.Response.Module;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Progame.Application.Utils;
using Progame.Domain.Models.Request.Question;

namespace Progame.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IUseCaseRespAsync<GetAllModulesResponse> _getAllModulesUseCaseRespAsync;
        private readonly IUseCaseAsync<GetModuleByIdRequest, ModuleOutResponse> _getByIdModuleUseCaseRespAsync;
        private readonly IUseCaseAsync<InsertModuleRequest, ModuleOutResponse> _insertModuleUseCaseAsync;
        private readonly IUseCaseAsync<UpdateModuleRequest, ModuleOutResponse> _updateModuleUseCaseAsync;
        private readonly IUseCaseAsync<DeleteModuleRequest, ModuleOutResponse> _deleteModuleUseCaseAsync;
        private readonly IUseCaseAsync<GetQuestionByModuleIdRequest, ModuleOutResponse> _getModuleWithQuestionsUseCaseAsync;
        private readonly IConfiguration _configuration;

        public ModuleController(IUseCaseRespAsync<GetAllModulesResponse> getAllModulesUseCaseRespAsync,
                            IUseCaseAsync<GetModuleByIdRequest, ModuleOutResponse> getByIdModuleUseCaseRespAsync,
                            IUseCaseAsync<InsertModuleRequest, ModuleOutResponse> insertModuleUseCaseAsync,
                            IUseCaseAsync<UpdateModuleRequest, ModuleOutResponse> updateModuleUseCaseAsync,
                            IUseCaseAsync<DeleteModuleRequest, ModuleOutResponse> deleteModuleUseCaseAsync,
                            IUseCaseAsync<GetQuestionByModuleIdRequest, ModuleOutResponse> getModuleWithQuestionsUseCaseAsync,
                             IConfiguration configuration)
        {
            _getAllModulesUseCaseRespAsync = getAllModulesUseCaseRespAsync;
            _getByIdModuleUseCaseRespAsync = getByIdModuleUseCaseRespAsync;
            _insertModuleUseCaseAsync = insertModuleUseCaseAsync;
            _updateModuleUseCaseAsync = updateModuleUseCaseAsync;
            _deleteModuleUseCaseAsync = deleteModuleUseCaseAsync;
            _getModuleWithQuestionsUseCaseAsync = getModuleWithQuestionsUseCaseAsync;
            _configuration = configuration;
        }

        /// <summary>
        /// Retorna todas as categorias.
        /// </summary>
        /// <response code="200">Categorias retornadas com sucesso.</response>
        /// <response code="204">Categorias retornadas, porém não existe nenhuma.</response>
        /// <response code="500">Ocorreu uma falha ao autenticar o usuário.</response>
        [HttpGet("FindAllAsync")]
        [ProducesResponseType(typeof(List<Module>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> FindAllAsync()
        {
            using (GetAllModulesResponse reponse = await _getAllModulesUseCaseRespAsync.ExecuteAsync())
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }

        [HttpGet("GetOne")]
        public async Task<IActionResult> GetOne([FromQuery] GetModuleByIdRequest request)
        {
            using (ModuleOutResponse reponse = await _getByIdModuleUseCaseRespAsync.Execute(request))
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }

        [HttpGet("GetWithQuestion")]
        public async Task<IActionResult> GetWithQuestion([FromQuery] GetQuestionByModuleIdRequest request)
        {
            using (ModuleOutResponse reponse = await _getModuleWithQuestionsUseCaseAsync.Execute(request))
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }

        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateAsync([FromBody] InsertModuleRequest request)
        {
            using (ModuleOutResponse reponse = await _insertModuleUseCaseAsync.Execute(request))
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateModuleRequest request)
        {
            using (ModuleOutResponse reponse = await _updateModuleUseCaseAsync.Execute(request))
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }

        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteModuleRequest request)
        {
            using (ModuleOutResponse reponse = await _deleteModuleUseCaseAsync.Execute(request))
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }
    }
}
