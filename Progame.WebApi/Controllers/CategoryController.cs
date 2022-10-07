using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Entities;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models.Request.Category;
using Progame.Domain.Models.Response.Category;
using Progame.Domain.Models.Response.Error;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Progame.Application.Utils;
using Progame.Domain.Interfaces;

namespace Progame.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUseCaseRespAsync<GetAllCategoryResponse> _getAllCategoriesUseCaseRespAsync;
        private readonly IUseCaseAsync<GetCategoryByIdRequest, CategoryOutResponse> _getByIdCategoryUseCaseRespAsync;
        private readonly IUseCaseAsync<InsertCategoryRequest, CategoryOutResponse> _insertCategoryUseCaseAsync;
        private readonly IUseCaseAsync<UpdateCategoryRequest, CategoryOutResponse> _updateCategoryUseCaseAsync;
        private readonly IUseCaseAsync<DeleteCategoryRequest, CategoryOutResponse> _deleteCategoryUseCaseAsync;
        private readonly IConfiguration _configuration;

        public CategoryController(IUseCaseRespAsync<GetAllCategoryResponse> getAllCategoriesUseCaseRespAsync,
                            IUseCaseAsync<GetCategoryByIdRequest, CategoryOutResponse> getByIdCategoryUseCaseRespAsync,
                            IUseCaseAsync<InsertCategoryRequest, CategoryOutResponse> insertCategoryUseCaseAsync,
                            IUseCaseAsync<UpdateCategoryRequest, CategoryOutResponse> updateCategoryUseCaseAsync,
                            IUseCaseAsync<DeleteCategoryRequest, CategoryOutResponse> deleteCategoryUseCaseAsync,
                             IConfiguration configuration)
        {
            _getAllCategoriesUseCaseRespAsync = getAllCategoriesUseCaseRespAsync;
            _getByIdCategoryUseCaseRespAsync = getByIdCategoryUseCaseRespAsync;
            _insertCategoryUseCaseAsync = insertCategoryUseCaseAsync;
            _updateCategoryUseCaseAsync = updateCategoryUseCaseAsync;
            _deleteCategoryUseCaseAsync = deleteCategoryUseCaseAsync;
            _configuration = configuration;
        }

        /// <summary>
        /// Retorna todas as categorias.
        /// </summary>
        /// <response code="200">Categorias retornadas com sucesso.</response>
        /// <response code="204">Categorias retornadas, porém não existe nenhuma.</response>
        /// <response code="500">Ocorreu uma falha ao autenticar o usuário.</response>
        [HttpGet("FindAllAsync")]
        [ProducesResponseType(typeof(List<Category>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> FindAllAsync()
        {
            using (GetAllCategoryResponse reponse = await _getAllCategoriesUseCaseRespAsync.ExecuteAsync())
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }

        [HttpGet("GetOne")]
        public async Task<IActionResult> GetOne([FromQuery] GetCategoryByIdRequest request)
        {
            using (CategoryOutResponse reponse = await _getByIdCategoryUseCaseRespAsync.Execute(request))
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }

        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateAsync([FromBody] InsertCategoryRequest request)
        {
            using (CategoryOutResponse reponse = await _insertCategoryUseCaseAsync.Execute(request))
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCategoryRequest request)
        {
            using (CategoryOutResponse reponse = await _updateCategoryUseCaseAsync.Execute(request))
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }

        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteCategoryRequest request)
        {
            using (CategoryOutResponse reponse = await _deleteCategoryUseCaseAsync.Execute(request))
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }
    }
}
