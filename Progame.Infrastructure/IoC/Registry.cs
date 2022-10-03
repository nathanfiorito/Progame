using Microsoft.Extensions.DependencyInjection;
using Progame.Application.UseCases.Auth;
using Progame.Application.UseCases.Category;
using Progame.Domain.Interfaces.Repositories;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models.Request.User;
using Progame.Domain.Models.Request.Category;
using Progame.Domain.Models.Response.User;
using Progame.Domain.Models.Response.Category;
using Progame.Infrastructure.Data.Repositories;
using Progame.Infrastructure.Repositories;

namespace Progame.Infrastructure.IoC
{
    public static class Registry
    {
        public static void RegisterApplication(this IServiceCollection services)
        {
            services.AddTransient<IUseCaseAsync<SignUpRequest, SignUpOutResponse>, SignUpUseCaseAsync>();
            services.AddTransient<IUseCaseAsync<SignInRequest, SignInOutResponse>, SignInUseCaseAsync>();
            services.AddTransient<IUseCaseAsync<GetCategoryByIdResponse, CategoryOutResponse>, GetCategoryByIdUseCaseAsync>();
            services.AddTransient<IUseCaseAsync<InsertCategoryRequest, CategoryOutResponse>, InsertCategoryUseCaseAsync>();
            services.AddTransient<IUseCaseRespAsync<GetAllCategoryResponse>, GetAllCategoriesUseCaseRespAsync>();
        }
        public static void RegisterDatabse(this IServiceCollection services)
        {
            services.AddTransient<IAnswerRepository, AnswerRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICompletedModulesRepository, CompletedModulesRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IQuestionTypeRepository, QuestionTypeRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
