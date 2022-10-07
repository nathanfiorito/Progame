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
            CategoryOutResponse response = new CategoryOutResponse();
            try
            {
                var category = _mapper.Map<Domain.Entities.Category>(request);

                var result = await _categoryRepository.CreateAsync(category);

                if (result)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Data = result;
                    response.Mensagem = "Categoria criada com sucesso!";
                }
                else
                {
                    response.StatusCode = HttpStatusCode.NoContent;
                    response.Data = null;
                    response.Mensagem = "Ocorreu um erro ao criar a categoria! Entre em contato com o adminsitrador do site.";
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
