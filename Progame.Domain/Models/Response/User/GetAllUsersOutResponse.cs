using System.Collections.Generic;
using System.Net;

namespace Progame.Domain.Models.Response.User
{
    public class GetAllUsersOutResponse : ResponseBase
    {
        public GetAllUsersOutResponse()
        {
        }

        public GetAllUsersOutResponse(HttpStatusCode statusCode, string mensagem, object data) : base(statusCode, mensagem, data)
        {
        }
    }
}
