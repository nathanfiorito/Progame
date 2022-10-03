using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progame.Domain.Models.Request.User
{
    public class SignUpRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Email { get; set; }

        public SignUpRequest()
        {
        }

        public SignUpRequest(string username, string password, string passwordConfirm, string email)
        {
            Username = username;
            Password = password;
            PasswordConfirm = passwordConfirm;
            Email = email;
        }
    }
}
