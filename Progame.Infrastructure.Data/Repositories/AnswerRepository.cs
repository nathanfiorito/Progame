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
    public class AnswerRepository : RepositoryBase<Answer>, IAnswerRepository
    {
        public AnswerRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<Answer>> GetByQuestionId(int questionId)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = " SELECT * FROM [progame].[dbo].[Answer] WHERE QuestionId = @QuestionId";

                    connection.Open();
                    var result = await connection.QueryAsync<Answer>(sql, new { QuestionId = questionId });
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
