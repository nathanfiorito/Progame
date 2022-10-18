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
using Progame.Domain.Models.Request.Answer;
using Progame.Domain.Models.Response.Answer;
using Progame.Application.UseCases.Answer;
using Progame.Domain.Models.Request.Module;
using Progame.Domain.Models.Response.Module;
using Progame.Application.UseCases.Module;
using Progame.Domain.Models.Request.CompletedModules;
using Progame.Domain.Models.Response.CompletedModules;
using Progame.Application.UseCases.CompletedModules;
using Progame.Domain.Models.Request.QuestionType;
using Progame.Domain.Models.Response.QuestionType;
using Progame.Application.UseCases.QuestionType;
using Progame.Domain.Models.Response.Question;
using Progame.Domain.Models.Request.Question;
using Progame.Application.UseCases.User;

namespace Progame.Infrastructure.IoC
{
    public static class Registry
    {
        public static void RegisterApplication(this IServiceCollection services)
        {
            #region[UseCases]

            #region[Auth]
            services.AddTransient<IUseCaseAsync<SignUpRequest, SignUpOutResponse>, SignUpUseCaseAsync>();
            services.AddTransient<IUseCaseAsync<SignInRequest, SignInOutResponse>, SignInUseCaseAsync>();
            services.AddTransient<IUseCaseRespAsync<GetAllUsersOutResponse>, FindAllAsyncUseCaseAsync>();
            #endregion

            #region[Category]
            services.AddTransient<IUseCaseAsync<GetCategoryByIdRequest, CategoryOutResponse>, GetCategoryByIdUseCaseAsync>();
            services.AddTransient<IUseCaseAsync<InsertCategoryRequest, CategoryOutResponse>, InsertCategoryUseCaseAsync>();
            services.AddTransient<IUseCaseAsync<UpdateCategoryRequest, CategoryOutResponse>, UpdateCategoryUseCaseAsync>();
            services.AddTransient<IUseCaseAsync<DeleteCategoryRequest, CategoryOutResponse>, DeleteCategoryUseCaseAsync>();
            services.AddTransient<IUseCaseRespAsync<GetAllCategoryResponse>, GetAllCategoriesUseCaseRespAsync>();
            #endregion

            #region[Answer]
            services.AddTransient<IUseCaseAsync<GetAnswerByIdRequest, AnswerOutResponse>, GetAnswerByIdUseCaseAsync>();
            services.AddTransient<IUseCaseAsync<InsertAnswerRequest, AnswerOutResponse>, InsertAnswerUseCaseAsync>();
            services.AddTransient<IUseCaseAsync<UpdateAnswerRequest, AnswerOutResponse>, UpdateAnswerUseCaseAsync>();
            services.AddTransient<IUseCaseAsync<DeleteAnswerRequest, AnswerOutResponse>, DeleteAnswerUseCaseAsync>();
            services.AddTransient<IUseCaseRespAsync<GetAllAnswersResponse>, GetAllAnswersUseCaseRespAsync>();
            #endregion

            #region[Module]
            services.AddTransient<IUseCaseAsync<GetModuleByIdRequest, ModuleOutResponse>, GetModuleByIdUseCaseAsync>();
            services.AddTransient<IUseCaseAsync<InsertModuleRequest, ModuleOutResponse>, InsertModuleUseCaseAsync>();
            services.AddTransient<IUseCaseAsync<UpdateModuleRequest, ModuleOutResponse>, UpdateModuleUseCaseAsync>();
            services.AddTransient<IUseCaseAsync<DeleteModuleRequest, ModuleOutResponse>, DeleteModuleUseCaseAsync>();
            services.AddTransient<IUseCaseRespAsync<GetAllModulesResponse>, GetAllModulesUseCaseRespAsync>();
            services.AddTransient<IUseCaseAsync<GetQuestionByModuleIdRequest, ModuleOutResponse>, GetModuleWithQuestionUseCaseAsync>();
            #endregion

            #region[CompletedModules]
            services.AddTransient<IUseCaseAsync<GetCompletedModuleByIdRequest, CompletedModuleOutResponse>, GetCompletedModuleByIdUseCaseRespAsync>();
            services.AddTransient<IUseCaseAsync<InsertCompletedModuleRequest, CompletedModuleOutResponse>, InsertCompletedModuleUseCaseAsync>();
            services.AddTransient<IUseCaseAsync<UpdateCompletedModuleRequest, CompletedModuleOutResponse>, UpdateCompletedModuleUseCaseAsync>();
            services.AddTransient<IUseCaseAsync<DeleteCompletedModuleRequest, CompletedModuleOutResponse>, DeleteCompletedModuleUseCaseAsync>();
            services.AddTransient<IUseCaseRespAsync<GetAllCompletedModulesResponse>, GetAllCompletedModulesUseCaseRespAsync>();
            #endregion

            #region[QuestionType]
            services.AddTransient<IUseCaseAsync<GetQuestionTypeByIdRequest, QuestionTypeOutResponse>, GetQuestionTypeByIdUseCaseRespAsync>();
            services.AddTransient<IUseCaseAsync<InsertQuestionTypeRequest, QuestionTypeOutResponse>, InsertQuestionTypeUseCaseAsync>();
            services.AddTransient<IUseCaseAsync<UpdateQuestionTypeRequest, QuestionTypeOutResponse>, UpdateQuestionTypeUseCaseAsync>();
            services.AddTransient<IUseCaseAsync<DeleteQuestionTypeRequest, QuestionTypeOutResponse>, DeleteQuestionTypeUseCaseAsync>();
            services.AddTransient<IUseCaseRespAsync<GetAllQuestionTypeResponse>, GetAllQuestionTypesUseCaseRespAsync>();
            #endregion

            #region[Question]
            services.AddTransient<IUseCaseAsync<GetQuestionByIdRequest, QuestionOutResponse>, GetQuestionByIdUseCaseAsync>();
            services.AddTransient<IUseCaseAsync<GetQuestionByModuleIdRequest, QuestionOutResponse >, GetQuestionByModuleIdUseCaseAsync>();
            services.AddTransient<IUseCaseAsync<InsertQuestionRequest, QuestionOutResponse>, InsertQuestionsUseCaseAsync>();
            services.AddTransient<IUseCaseAsync<UpdateQuestionRequest, QuestionOutResponse>, UpdateQuestionsUseCaseAsync>();
            services.AddTransient<IUseCaseAsync<DeleteQuestionRequest, QuestionOutResponse>, DeleteQuestionUseCaseAsync>();
            services.AddTransient<IUseCaseRespAsync<GetAllQuestionsResponse>, GetAllQuestionsUseCaseRespAsync>();
            #endregion

            #endregion
        }
        public static void RegisterDatabse(this IServiceCollection services)
        {
            services.AddTransient<IAnswerRepository, AnswerRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IModuleRepository, ModuleRepository>();
            services.AddTransient<ICompletedModulesRepository, CompletedModulesRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IQuestionTypeRepository, QuestionTypeRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
