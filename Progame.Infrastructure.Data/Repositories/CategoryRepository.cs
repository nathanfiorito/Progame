using Dapper;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Entities;
using Progame.Domain.Interfaces.Repositories;

namespace Progame.Infrastructure.Data.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
