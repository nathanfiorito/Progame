using MediatR;
using Progame.Domain.Models.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progame.Domain.Models.Request.User
{
    public class SignInRequest/* : IRequest<SignInOutResponse>*/
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
