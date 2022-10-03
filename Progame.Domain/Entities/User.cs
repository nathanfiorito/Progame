using Progame.Domain.Models.Request.User;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;

namespace Progame.Domain.Entities
{
    public class User : EntityBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Experience { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool IsAdmin { get; set; }
        public string ImgUrl { get; set; }

        public User()
        {
        }


        public User(SignUpRequest request)
        {
            Username = request.Username;
            Password = request.Password;
            Email = request.Email;
            CreatePasswordHash(request.Password);
        }

        private void CreatePasswordHash(string password)
        {
            using(var hmac = new HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool ComparePassword(string password, string passwordConfirm)
        {
            if (password == passwordConfirm)
                return true;
            else
                return false;
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
