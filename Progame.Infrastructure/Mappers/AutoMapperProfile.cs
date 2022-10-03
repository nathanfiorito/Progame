using AutoMapper;
using Progame.Domain.Entities;
using Progame.Domain.Models.Request.Category;
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
            CreateMap<InsertCategoryRequest,Category>();
        }
    }
}
