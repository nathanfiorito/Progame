using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progame.Domain.Models.Request.Question
{
    public class UpdateQuestionRequest : BaseRequest
    {
        public string QuestionText { get; set; }
        public int ModuleId { get; set; }
        public int CorrectAnswerId { get; set; }
        public int QuestionTypeId { get; set; }
    }
}
