using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progame.Domain.Models.Request.CompletedModules
{
    public class UpdateCompletedModuleRequest : BaseRequest
    {
        public int UserId { get; set; }
        public int ModuleId { get; set; }
    }
}
