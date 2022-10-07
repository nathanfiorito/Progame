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
using Progame.Domain.Entities;

namespace Progame.Application.UseCases.Category
{
    public class DeleteCategoryUseCaseAsync : UseCaseBase, IUseCaseAsync<DeleteCategoryRequest, CategoryOutResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public DeleteCategoryUseCaseAsync(ICategoryRepository categoryRepository,
                                IMapper mapper,
                                IConfiguration configuration)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<CategoryOutResponse> Execute(DeleteCategoryRequest request)
        {
            CategoryOutResponse response = new CategoryOutResponse();
            try
            {
                var category = await _categoryRepository.FindByIdAsync(request.Id);

                if (category == null)
                    return new CategoryOutResponse() { StatusCode = HttpStatusCode.NoContent, Mensagem = "Category not found!" };

                var result = await _categoryRepository.DeleteAsync(category.Id);

                if (result)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Data = result;
                    response.Mensagem = "Categoria deletada com sucesso!";
                }
                else
                {
                    response.StatusCode = HttpStatusCode.NoContent;
                    response.Data = null;
                    response.Mensagem = "Ocorreu um erro ao criar a deletar! Entre em contato com o adminsitrador do site.";
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
