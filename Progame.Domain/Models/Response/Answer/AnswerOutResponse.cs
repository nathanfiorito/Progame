using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Progame.Domain.Models.Response.Answer
{
    public class AnswerOutResponse : ResponseBase
    {
        public AnswerOutResponse()
        {
        }

        public AnswerOutResponse(HttpStatusCode statusCode, string mensagem, object data) : base(statusCode, mensagem, data)
        {
        }

    }
}
