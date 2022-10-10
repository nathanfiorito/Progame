using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces.Repositories;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models;
using Progame.Domain.Models.Request.Category;
using Progame.Domain.Models.Response.Category;
using Progame.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Progame.Application.UseCases.Category
{
    public class GetAllCategoriesUseCaseRespAsync : UseCaseBase, IUseCaseRespAsync<GetAllCategoryResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoriesUseCaseRespAsync(IConfiguration configuration,
                                        ICategoryRepository categoryRepository)
        {
            _configuration = configuration;
            _categoryRepository = categoryRepository;
        }

        public async Task<GetAllCategoryResponse> ExecuteAsync()
        {
            try
            {
                var result = await _categoryRepository.FindAllAsync();

                if (result.Any())
                {
                    var msg = "Data returned with success!";
                    return new GetAllCategoryResponse(HttpStatusCode.OK, msg, result);
                }
                else
                {
                    var msg = "An error occurred while attempt to find the category! Contact website administrator.";
                    return new GetAllCategoryResponse(HttpStatusCode.BadRequest, msg, null);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
