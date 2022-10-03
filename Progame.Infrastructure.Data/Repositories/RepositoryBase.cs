using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Progame.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly IConfiguration _configuration;
        private readonly Type type;
        private readonly PropertyInfo[] propertyInfos;

        public readonly string connectionString;

        public RepositoryBase(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
            type = typeof(TEntity);
            propertyInfos = type.GetProperties();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var entity = await this.FindByIdAsync(id);

                    if (entity == null)
                        return false;

                    return await connection.DeleteAsync(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IQueryable<TEntity>> FindAllAsync()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = $@" SELECT * FROM {type.Name}";

                    connection.Open();
                    var result = await connection.GetAllAsync<TEntity>();

                    return result.AsQueryable();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = $@" SELECT * FROM {type.Name} WHERE Id = @Id";

                    connection.Open();
                    var result = await connection.QueryAsync<TEntity>(sql, new { Id = id });
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> CreateAsync(TEntity entity)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var affectedRows = await connection.InsertAsync(entity);
                    return affectedRows == 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    return await connection.UpdateAsync(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
