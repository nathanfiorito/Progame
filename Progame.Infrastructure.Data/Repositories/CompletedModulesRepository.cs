using Dapper;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Entities;
using Progame.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Progame.Infrastructure.Data.Repositories
{
    public class CompletedModulesRepository : RepositoryBase<CompletedModules>, ICompletedModulesRepository
    {
        public CompletedModulesRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<CompletedModules>> FindByUserIdAsync(int userId)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = " SELECT * FROM [progame].[dbo].[CompletedModules] WHERE UserId = @UserId";

                    connection.Open();
                    var result = await connection.QueryAsync<CompletedModules>(sql, new { UserId = userId });
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
