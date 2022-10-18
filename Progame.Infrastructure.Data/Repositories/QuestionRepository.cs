using Dapper;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Entities;
using Progame.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace Progame.Infrastructure.Data.Repositories
{
    public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
    {
        public QuestionRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<Question>> GetByModuleId(int moduleId)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = " SELECT * FROM [progame].[dbo].[Question] WHERE ModuleId = @ModuleId";

                    connection.Open();
                    var result = await connection.QueryAsync<Question>(sql, new { ModuleId = moduleId });
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
