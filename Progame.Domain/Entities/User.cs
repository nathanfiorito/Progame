using Dapper.Contrib.Extensions;
using Progame.Domain.Models.Request.User;
using System;
using System.Linq;
using System.Security.Cryptography;

namespace Progame.Domain.Entities
{
    [Table("Users")]
    public class User : EntityBase
    {
        #region[Fields]
        public string Username { get; set; }
        public string Email { get; set; }
        public int Experience { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool IsAdmin { get; set; }
        public string ImgUrl { get; set; }
        #endregion

        #region[Constructors]
        public User()
        {
        }

        public User(SignUpRequest request)
        {
            Username = request.Username;
            Email = request.Email;
            CreatedAt = DateTime.Now;
            CreatePasswordHash(request.Password);
        }
        #endregion

        #region [Public Methods]
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
        #endregion

        #region [Private Methods]
        private void CreatePasswordHash(string password)
        {
            using(var hmac = new HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        #endregion
    }
}
