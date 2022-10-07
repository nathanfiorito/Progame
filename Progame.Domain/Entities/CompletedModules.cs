using Dapper.Contrib.Extensions;
using Progame.Domain.Models.Request.CompletedModules;
using Progame.Domain.Models.Request.Module;
using System;

namespace Progame.Domain.Entities
{
    [Table("CompletedModules")]
    public class CompletedModules : EntityBase
    {
        public CompletedModules()
        {
        }

        public CompletedModules(InsertCompletedModuleRequest request)
        {
            UserId = request.UserId;
            ModuleId = request.ModuleId;
            CreatedAt = DateTime.Now;
        }

        public CompletedModules(UpdateCompletedModuleRequest request)
        {
            UserId = request.UserId;
            ModuleId = request.ModuleId;
            UpdatedAt = DateTime.Now;
        }


        public int UserId { get; set; }
        public int ModuleId { get; set; }

    }
}
