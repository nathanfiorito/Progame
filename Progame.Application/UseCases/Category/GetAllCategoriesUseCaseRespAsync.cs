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
                GetAllCategoryResponse categoryOutResponse = new GetAllCategoryResponse();

                var result = await _categoryRepository.FindAllAsync();

                if (result.Count() > 0)
                {
                    categoryOutResponse.StatusCode = HttpStatusCode.OK;
                    categoryOutResponse.Data = result;
                    categoryOutResponse.Mensagem = "Dados retornados com sucesso!";
                }
                else
                {
                    categoryOutResponse.StatusCode = HttpStatusCode.NoContent;
                    categoryOutResponse.Data = null;
                    categoryOutResponse.Mensagem = "Não foi encontrado nenhum resultado com os parametros informados.";
                }
                return categoryOutResponse;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
