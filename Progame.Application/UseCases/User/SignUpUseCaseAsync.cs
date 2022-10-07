using AutoMapper;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Entities;
using Progame.Domain.Interfaces;
using Progame.Domain.Interfaces.Repositories;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models;
using Progame.Domain.Models.Request.User;
using Progame.Domain.Models.Response.User;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Progame.Application.UseCases.Auth
{
    public class SignUpUseCaseAsync : UseCaseBase, IUseCaseAsync<SignUpRequest, SignUpOutResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public SignUpUseCaseAsync(IConfiguration configuration,
                                IMapper mapper,
                                IUserRepository userRepository)
        {
            _configuration = configuration;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<SignUpOutResponse> Execute(SignUpRequest request)
        {
            SignUpOutResponse signUpOutResponse = new SignUpOutResponse();
            try
            {
                var userExists = await _userRepository.GetByUsername(request.Username);
                if(userExists != null)
                    return new SignUpOutResponse() { StatusCode = HttpStatusCode.Ambiguous, Mensagem = "Já existe um usuário com esse nome." };

                if (!User.ComparePassword(request.Password,request.PasswordConfirm))
                {
                    return new SignUpOutResponse() { StatusCode = HttpStatusCode.BadRequest, Mensagem = "As senhas não coincidem!" }; 
                }

                var user = _mapper.Map<Domain.Entities.User>(request);

                var result = await _userRepository.CreateAsync(user);

                if (result)
                {
                    signUpOutResponse.StatusCode = HttpStatusCode.OK;
                    signUpOutResponse.Data = result;
                    signUpOutResponse.Mensagem = "Usuário criado com sucesso!";
                }
                else
                {
                    signUpOutResponse.StatusCode = HttpStatusCode.NoContent;
                    signUpOutResponse.Data = null;
                    signUpOutResponse.Mensagem = "Ocorreu um erro ao criar o usuario! Entre em contato com o adminsitrador do site.";
                }
                return signUpOutResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
    }
}
