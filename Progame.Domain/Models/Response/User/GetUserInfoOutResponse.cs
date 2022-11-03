using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Progame.Domain.Models.Response.User
{
    public class GetUserInfoOutResponse : ResponseBase
    {
        public GetUserInfoOutResponse(HttpStatusCode statusCode, string mensagem, object data) : base(statusCode, mensagem, data)
        {
        }
    }
}
