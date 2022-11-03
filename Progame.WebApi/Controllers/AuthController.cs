using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Progame.Application.Utils;
using Progame.Domain.Interfaces;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models.Request.User;
using Progame.Domain.Models.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Progame.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUseCaseAsync<SignUpRequest, SignUpOutResponse> _signUpUseCaseAsync;
        private readonly IUseCaseAsync<SignInRequest, SignInOutResponse> _signInUseCaseAsync;
        private readonly IUseCaseRespAsync<GetAllUsersOutResponse> _findAllAsyncUseCaseAsync;
        private readonly IUseCaseAsync<GetUserInfoRequest, GetUserInfoOutResponse> _getUserInfo;
        private readonly IConfiguration _configuration;

        public AuthController(
            IUseCaseAsync<SignUpRequest, SignUpOutResponse> signUpUseCaseAsync,
            IUseCaseAsync<SignInRequest, SignInOutResponse> signInUseCaseAsync,
            IUseCaseRespAsync<GetAllUsersOutResponse> findAllAsyncUseCaseAsync,
            IUseCaseAsync<GetUserInfoRequest, GetUserInfoOutResponse> getUserInfo,
            IConfiguration configuration)
        {
            _signUpUseCaseAsync = signUpUseCaseAsync;
            _signInUseCaseAsync = signInUseCaseAsync;
            _findAllAsyncUseCaseAsync = findAllAsyncUseCaseAsync;
            _getUserInfo = getUserInfo;
            _configuration = configuration;
        }

        /// <summary>
        /// Autenticar usuário.
        /// </summary>
        /// <param name="request">Objeto com nome de usuário e senha.</param>
        /// <response code="200">Usuário autenticado com sucesso.</response>
        /// <response code="500">Ocorreu uma falha ao autenticar o usuário.</response>
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInRequest request)
        {
            using (SignInOutResponse reponse = await _signInUseCaseAsync.Execute(request))
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequest request)
        {
            using (SignUpOutResponse reponse = await _signUpUseCaseAsync.Execute(request))
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }

        [HttpGet("FindAllAsync")]
        public async Task<IActionResult> FindAllAsync()
        {
            using (GetAllUsersOutResponse reponse = await _findAllAsyncUseCaseAsync.ExecuteAsync())
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }

        [HttpGet("GetUserInfo")]
        public async Task<IActionResult> GetExp([FromQuery] GetUserInfoRequest request)
        {
            using (GetUserInfoOutResponse reponse = await _getUserInfo.Execute(request))
            {
                return new ContentResult() { Content = JsonConverter.Convert(reponse), StatusCode = (int)reponse.StatusCode };
            }
        }
    }
}
