using AutoMapper;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces.Repositories;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models;
using Progame.Domain.Models.Request.Category;
using Progame.Domain.Models.Response.Category;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Progame.Application.UseCases.Category
{
    public class InsertCategoryUseCaseAsync : UseCaseBase, IUseCaseAsync<InsertCategoryRequest, CategoryOutResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public InsertCategoryUseCaseAsync(ICategoryRepository categoryRepository,
                                IMapper mapper,
                                IConfiguration configuration)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<CategoryOutResponse> Execute(InsertCategoryRequest request)
        {
            try
            {
                var result = await _categoryRepository.CreateAsync(_mapper.Map<Domain.Entities.Category>(request));

                if (result)
                {
                    var msg = "Category inserted!";
                    return new CategoryOutResponse(HttpStatusCode.OK, msg, result);
                }
                else
                {
                    var msg = "An error occurred while attempt to insert the category! Contact website administrator.";
                    return new CategoryOutResponse(HttpStatusCode.BadRequest, msg, null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
