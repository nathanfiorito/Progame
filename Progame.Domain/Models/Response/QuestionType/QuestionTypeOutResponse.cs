using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Progame.Domain.Models.Response.QuestionType
{
    public class QuestionTypeOutResponse : ResponseBase
    {
        public QuestionTypeOutResponse()
        {
        }

        public QuestionTypeOutResponse(HttpStatusCode statusCode, string mensagem, object data) : base(statusCode, mensagem, data)
        {
        }


    }
}
