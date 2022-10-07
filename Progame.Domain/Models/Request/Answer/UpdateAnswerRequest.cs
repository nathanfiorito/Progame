using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progame.Domain.Models.Request.Answer
{
    public class UpdateAnswerRequest : BaseRequest
    {
        public string AnswerText { get; set; }
        public int QuestionId { get; set; }
    }
}
