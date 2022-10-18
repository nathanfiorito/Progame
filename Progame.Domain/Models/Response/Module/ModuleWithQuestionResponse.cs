using System.Collections.Generic;

namespace Progame.Domain.Models.Response.Module
{
    public class ModuleWithQuestionResponse
    {
        public Entities.Module Module { get; set; }
        public List<Entities.Question> Questions { get; set; }
    }
}
