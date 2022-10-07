using Dapper.Contrib.Extensions;
using Progame.Domain.Models.Request.Module;
using System;

namespace Progame.Domain.Entities
{
    [Table("Module")]
    public class Module : EntityBase
    {
        public Module()
        {
        }

        public Module(InsertModuleRequest request)
        {
            ModuleName = request.ModuleName;
            SupportText = request.SupportText;
            ImgUrl = request.ImgUrl;
            Resume = request.Resume;
            CategoryId = request.CategoryId;
            CreatedAt = DateTime.Now;
        }



        public string ModuleName { get; set; }
        public string SupportText { get; set; }
        public string ImgUrl { get; set; }
        public string Resume { get; set; }
        public int CategoryId { get; set; }


    }
}
