using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Progame.Domain.Models.Response.Category
{
    public class CategoryOutResponse : ResponseBase
    {
        public CategoryOutResponse()
        {
        }

        public CategoryOutResponse(HttpStatusCode statusCode, string mensagem, object data) : base(statusCode, mensagem, data)
        {
        }

    }
}
