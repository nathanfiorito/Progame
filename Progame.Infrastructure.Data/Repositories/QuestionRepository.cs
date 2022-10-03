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
    }
}
