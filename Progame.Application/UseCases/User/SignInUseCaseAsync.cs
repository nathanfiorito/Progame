using Microsoft.Extensions.Configuration;
using Progame.Domain.Entities;
using Progame.Domain.Models;
using Progame.Domain.Models.Request.User;
using Progame.Domain.Models.Response.User;
using Progame.Infrastructure.Repositories;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Progame.Domain.Interfaces.UseCases;
using System.Net;
using Progame.Domain.Interfaces.Repositories;

namespace Progame.Application.UseCases.Auth
{
    public class SignInUseCaseAsync : UseCaseBase, IUseCaseAsync<SignInRequest, SignInOutResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public SignInUseCaseAsync(IConfiguration configuration,
                                IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
    }

        public async Task<SignInOutResponse> Execute(SignInRequest request)
        {
            SignInOutResponse signInOutResponse = new SignInOutResponse();
            try
            {
                var result = await _userRepository.GetByUsername(request.Username);

                if(result == null)
                    return new SignInOutResponse() { StatusCode = HttpStatusCode.Unauthorized, Mensagem = "User not found!" };

                if (!Domain.Entities.User.VerifyPasswordHash(request.Password, result.PasswordHash, result.PasswordSalt))
                    return new SignInOutResponse() { StatusCode = HttpStatusCode.Unauthorized, Mensagem = "Wrong password!" };

                string token = CreateToken(result);

                if (result != null)
                {
                    signInOutResponse.StatusCode = HttpStatusCode.OK;
                    signInOutResponse.Data = token;
                    signInOutResponse.Mensagem = "Usuário autenticado com sucesso!";
                }
                else
                {
                    signInOutResponse.StatusCode = HttpStatusCode.NoContent;
                    signInOutResponse.Data = null;
                    signInOutResponse.Mensagem = "Ocorreu um erro ao autenticar o usuario! Entre em contato com o adminsitrador do site.";
                }

                return signInOutResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string CreateToken(Domain.Entities.User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("username", user.Username),  
                new Claim("email", user.Email),
                new Claim("experience", user.Experience.ToString()),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSecret").Value));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
