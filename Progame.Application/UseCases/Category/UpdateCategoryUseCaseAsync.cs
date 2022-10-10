using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models.Request.Category;
using Progame.Domain.Models.Response.Category;
using Progame.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces.Repositories;
using System.Net;
using Progame.Domain.Models.Response.User;

namespace Progame.Application.UseCases.Category
{
    public class UpdateCategoryUseCaseAsync : UseCaseBase, IUseCaseAsync<UpdateCategoryRequest, CategoryOutResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UpdateCategoryUseCaseAsync(ICategoryRepository categoryRepository,
                                IMapper mapper,
                                IConfiguration configuration)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<CategoryOutResponse> Execute(UpdateCategoryRequest request)
        {
            try
            {
                var category = await _categoryRepository.FindByIdAsync(request.Id);

                if (category == null)
                    return new CategoryOutResponse(HttpStatusCode.NotFound, "Category not found!", null);

                var result = await _categoryRepository.UpdateAsync(_mapper.Map<Domain.Entities.Category>(request));

                if (result)
                {
                    var msg = "Category updated!";
                    return new CategoryOutResponse(HttpStatusCode.OK, msg, result);
                }
                else
                {
                    var msg = "An error occurred while attempt to update the category! Contact website administrator.";
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
