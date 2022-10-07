using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progame.Domain.Models.Request.QuestionType
{
    public class InsertQuestionTypeRequest : BaseRequest
    {
        public string Type { get; set; }
    }
}
