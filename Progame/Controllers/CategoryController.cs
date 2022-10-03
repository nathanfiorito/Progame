using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models.Request.Category;
using Progame.Domain.Models.Response.Category;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Progame.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUseCaseRespAsync<GetAllCategoryResponse> _getAllCategoriesUseCaseRespAsync;
        private readonly IUseCaseAsync<GetCategoryByIdResponse, CategoryOutResponse> _getByIdCategoriesUseCaseRespAsync;
        private readonly IUseCaseAsync<InsertCategoryRequest, CategoryOutResponse> _insertCategoriesUseCaseAsync;
        private readonly IConfiguration _configuration;

        public CategoryController(IUseCaseRespAsync<GetAllCategoryResponse> getAllCategoriesUseCaseRespAsync,
                            IUseCaseAsync<GetCategoryByIdResponse, CategoryOutResponse> getByIdCategoriesUseCaseRespAsync,
                            IUseCaseAsync<InsertCategoryRequest, CategoryOutResponse> insertCategoriesUseCaseAsync,
                             IConfiguration configuration)
        {
            _getAllCategoriesUseCaseRespAsync = getAllCategoriesUseCaseRespAsync;
            _getByIdCategoriesUseCaseRespAsync = getByIdCategoriesUseCaseRespAsync;
            _insertCategoriesUseCaseAsync = insertCategoriesUseCaseAsync;
            _configuration = configuration;
        }

        [HttpGet("FindAllAsync")]
        public async Task<IActionResult> FindAllAsync()
        {
            try
            {
                using (GetAllCategoryResponse reponse = await _getAllCategoriesUseCaseRespAsync.ExecuteAsync())
                {
                    if (reponse.StatusCode == HttpStatusCode.OK)
                        return Ok(reponse);
                    else
                        return BadRequest(reponse);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("GetOne")]
        public async Task<IActionResult> GetOne([FromQuery] GetCategoryByIdResponse request)
        {
            try
            {
                using (CategoryOutResponse reponse = await _getByIdCategoriesUseCaseRespAsync.Execute(request))
                {
                    if (reponse.StatusCode == HttpStatusCode.OK)
                        return Ok(reponse);
                    else
                        return BadRequest(reponse);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateAsync([FromQuery] InsertCategoryRequest request)
        {
            try
            {
                using (CategoryOutResponse reponse = await _insertCategoriesUseCaseAsync.Execute(request))
                {
                    if (reponse.StatusCode == HttpStatusCode.OK)
                        return Ok(reponse);
                    else
                        return BadRequest(reponse);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromQuery] GetCategoryByIdResponse request)
        {
            try
            {
                using (CategoryOutResponse reponse = await _getByIdCategoriesUseCaseRespAsync.Execute(request))
                {
                    if (reponse.StatusCode == HttpStatusCode.OK)
                        return Ok(reponse);
                    else
                        return BadRequest(reponse);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync([FromQuery] GetCategoryByIdResponse request)
        {
            try
            {
                using (CategoryOutResponse reponse = await _getByIdCategoriesUseCaseRespAsync.Execute(request))
                {
                    if (reponse.StatusCode == HttpStatusCode.OK)
                        return Ok(reponse);
                    else
                        return BadRequest(reponse);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
