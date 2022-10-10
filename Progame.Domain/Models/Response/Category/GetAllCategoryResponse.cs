using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Progame.Domain.Models.Response.Category
{
    public class GetAllCategoryResponse : ResponseBase
    {
        public GetAllCategoryResponse()
        {
        }

        public GetAllCategoryResponse(HttpStatusCode statusCode, string mensagem, object data) : base(statusCode, mensagem, data)
        {
        }
    }
}
