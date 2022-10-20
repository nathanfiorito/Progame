using Dapper;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Entities;
using Progame.Domain.Interfaces.Repositories;
using Progame.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Progame.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<User> GetByUsername(string username)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = " SELECT * FROM [progame].[dbo].[Users] WHERE Username = @Username OR Email = @Username";

                    connection.Open();
                    var result = await connection.QueryAsync<User>(sql, new { Username = username });
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetUserExperience(int id)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = " SELECT * FROM [progame].[dbo].[Users] WHERE Id = @Id";

                    connection.Open();
                    var result = await connection.QueryAsync<User>(sql, new { Id = id });
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
