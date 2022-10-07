using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models.Request.CompletedModules;
using Progame.Domain.Models.Response.CompletedModules;
using System;
using Xunit;

namespace Progame.Application.Tests
{
    public class CompletedModulesTest
    {
        private readonly IUseCaseRespAsync<GetAllCompletedModulesResponse> _getAllCompletedModulesUseCaseRespAsync;
        private readonly IUseCaseAsync<GetCompletedModuleByIdRequest, CompletedModuleOutResponse> _getByIdCompletedModuleUseCaseRespAsync;
        private readonly IUseCaseAsync<InsertCompletedModuleRequest, CompletedModuleOutResponse> _insertCompletedModuleUseCaseAsync;
        private readonly IUseCaseAsync<UpdateCompletedModuleRequest, CompletedModuleOutResponse> _updateCompletedModuleUseCaseAsync;
        private readonly IUseCaseAsync<DeleteCompletedModuleRequest, CompletedModuleOutResponse> _deleteCompletedModuleUseCaseAsync;
        private readonly IConfiguration _configuration;

        public CompletedModulesTest(IUseCaseRespAsync<GetAllCompletedModulesResponse> getAllCompletedModulesUseCaseRespAsync,
                            IUseCaseAsync<GetCompletedModuleByIdRequest, CompletedModuleOutResponse> getByIdCompletedModuleUseCaseRespAsync,
                            IUseCaseAsync<InsertCompletedModuleRequest, CompletedModuleOutResponse> insertCompletedModuleUseCaseAsync,
                            IUseCaseAsync<UpdateCompletedModuleRequest, CompletedModuleOutResponse> updateCompletedModuleUseCaseAsync,
                            IUseCaseAsync<DeleteCompletedModuleRequest, CompletedModuleOutResponse> deleteCompletedModuleUseCaseAsync,
                             IConfiguration configuration)
        {
            _getAllCompletedModulesUseCaseRespAsync = getAllCompletedModulesUseCaseRespAsync;
            _getByIdCompletedModuleUseCaseRespAsync = getByIdCompletedModuleUseCaseRespAsync;
            _insertCompletedModuleUseCaseAsync = insertCompletedModuleUseCaseAsync;
            _updateCompletedModuleUseCaseAsync = updateCompletedModuleUseCaseAsync;
            _deleteCompletedModuleUseCaseAsync = deleteCompletedModuleUseCaseAsync;
            _configuration = configuration;
        }

        [Fact(DisplayName = "Inserir um novo regsitro.")]
        public async void CompletedModules_InsertAsync()
        {
            //Arrange
            InsertCompletedModuleRequest request = new InsertCompletedModuleRequest()
            {
                UserId = 1,
                ModuleId = 1
            };

            //Act
            CompletedModuleOutResponse response = await _insertCompletedModuleUseCaseAsync.Execute(request);

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Procurar todos os regsitros.")]
        public async void CompletedModules_FindAllAsync()
        {
            //Arrange

            //Act
            GetAllCompletedModulesResponse response = await _getAllCompletedModulesUseCaseRespAsync.ExecuteAsync();

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Procurar regsitro por Id.")]
        public async void CompletedModules_FindByIdAsync()
        {
            //Arrange
            GetCompletedModuleByIdRequest request = new GetCompletedModuleByIdRequest()
            {
                Id = 1
            };

            //Act
            CompletedModuleOutResponse response = await _getByIdCompletedModuleUseCaseRespAsync.Execute(request);

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Atualizar um regsitro.")]
        public async void CompletedModules_UpdateAsync()
        {
            //Arrange
            UpdateCompletedModuleRequest request = new UpdateCompletedModuleRequest()
            {
                Id = 1,
                UserId = 1,
                ModuleId = 1
            };

            //Act
            CompletedModuleOutResponse response = await _updateCompletedModuleUseCaseAsync.Execute(request);

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Deletar um regsitro.")]
        public async void CompletedModules_DeleteAsync()
        {
            //Arrange
            DeleteCompletedModuleRequest request = new DeleteCompletedModuleRequest()
            {
                Id = 1
            };

            //Act
            CompletedModuleOutResponse response = await _deleteCompletedModuleUseCaseAsync.Execute(request);

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
    }
}
