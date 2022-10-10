using AutoMapper;
using Progame.Domain.Entities;
using Progame.Domain.Models.Request.Answer;
using Progame.Domain.Models.Request.Category;
using Progame.Domain.Models.Request.CompletedModules;
using Progame.Domain.Models.Request.Module;
using Progame.Domain.Models.Request.Question;
using Progame.Domain.Models.Request.QuestionType;
using Progame.Domain.Models.Request.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progame.Infrastructure.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<SignUpRequest, User>().ConstructUsing(x => new User(x));

            CreateMap<InsertAnswerRequest, Answer>().ConstructUsing(x => new Answer(x));
            CreateMap<UpdateAnswerRequest, Answer>().ConstructUsing(x => new Answer(x));

            CreateMap<InsertCategoryRequest, Category>().ConstructUsing(x => new Category(x));
            CreateMap<UpdateCategoryRequest, Category>().ConstructUsing(x => new Category(x));

            CreateMap<InsertCompletedModuleRequest, CompletedModules>().ConstructUsing(x => new CompletedModules(x));
            CreateMap<UpdateCompletedModuleRequest, CompletedModules>().ConstructUsing(x => new CompletedModules(x));

            CreateMap<InsertModuleRequest, Module>().ConstructUsing(x => new Module(x));
            CreateMap<UpdateModuleRequest, Module>().ConstructUsing(x => new Module(x));

            CreateMap<InsertQuestionRequest, Question>().ConstructUsing(x => new Question(x));
            CreateMap<UpdateQuestionRequest, Question>().ConstructUsing(x => new Question(x));

            CreateMap<InsertQuestionTypeRequest, QuestionType>().ConstructUsing(x => new QuestionType(x));
            CreateMap<UpdateQuestionTypeRequest, QuestionType>().ConstructUsing(x => new QuestionType(x));
        }
    }
}
