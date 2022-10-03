﻿using Dapper;
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
    }
}