using Dapper;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Entities;
using Progame.Domain.Interfaces.Repositories;
using Progame.Domain.Models.Response.Module;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Progame.Infrastructure.Data.Repositories
{
    public class ModuleRepository : RepositoryBase<Module>, IModuleRepository
    {
        public ModuleRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<Module> GetModuleWithQuestion(int moduleId)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var moduleSql = "SELECT * FROM [progame].[dbo].[Module] WHERE Id = @ModuleId";

                    connection.Open();
                    var result = (await connection.QueryAsync<Module>(moduleSql, new { ModuleId = moduleId }));
                    return result.First();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
