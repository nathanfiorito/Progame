using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models;
using Progame.Domain.Interfaces.Repositories;
using Progame.Domain.Models.Request.Category;
using Progame.Domain.Models.Response.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Progame.Application.UseCases.Category
{
    public class GetCategoryByIdUseCaseAsync : UseCaseBase, IUseCaseAsync<GetCategoryByIdRequest, CategoryOutResponse> 
    {
        private readonly IConfiguration _configuration;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryByIdUseCaseAsync(IConfiguration configuration,
                                    ICategoryRepository categoryRepository)
        {
            _configuration = configuration;
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryOutResponse> Execute(GetCategoryByIdRequest request)
        {
            CategoryOutResponse categoryOutResponse = new CategoryOutResponse();
            try
            {
                var result = await _categoryRepository.FindByIdAsync(request.Id);

                if (result != null)
                {
                    categoryOutResponse.StatusCode = HttpStatusCode.OK;
                    categoryOutResponse.Data = result;
                    categoryOutResponse.Mensagem= "Dados retornados com sucesso!";
                }
                else
                {
                    categoryOutResponse.StatusCode = HttpStatusCode.NoContent;
                    categoryOutResponse.Data = null;
                    categoryOutResponse.Mensagem = "Não foi encontrado nenhum resultado com os parametros informados.";
                }
                return categoryOutResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
