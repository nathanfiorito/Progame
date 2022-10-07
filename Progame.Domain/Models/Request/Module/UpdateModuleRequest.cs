using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progame.Domain.Models.Request.Module
{
    public class UpdateModuleRequest : BaseRequest
    {
        public string ModuleName { get; set; }
        public string SupportText { get; set; }
        public string ImgUrl { get; set; }
        public string Resume { get; set; }
        public int CategoryId { get; set; }

    }
}
