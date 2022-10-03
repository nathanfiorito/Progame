using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Progame.Infrastructure.Mappers
{
    public static class AutoMapperBootstrapper
    {
        public static void RegisterAutoMapper<TProfile>(this IServiceCollection serviceCollection) where TProfile : Profile, new()
        {
            var autoMapper = new MapperConfiguration(x => x.AddProfile<TProfile>());
            serviceCollection.AddSingleton(autoMapper.CreateMapper());
        }
    }
}
