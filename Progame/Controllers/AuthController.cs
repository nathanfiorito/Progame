using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models.Request.User;
using Progame.Domain.Models.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Progame.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUseCaseAsync<SignUpRequest, SignUpOutResponse> _signUpUseCaseAsync;
        private readonly IUseCaseAsync<SignInRequest, SignInOutResponse> _signInUseCaseAsync;
        private readonly IConfiguration _configuration;

        public AuthController(IUseCaseAsync<SignUpRequest, SignUpOutResponse> signUpUseCaseAsync,
                             IUseCaseAsync<SignInRequest, SignInOutResponse> signInUseCaseAsync,
                             IConfiguration configuration)
        {
            _signUpUseCaseAsync = signUpUseCaseAsync;
            _signInUseCaseAsync = signInUseCaseAsync;
            _configuration = configuration;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInRequest request)
        {
            try
            {
                using (SignInOutResponse reponse = await _signInUseCaseAsync.Execute(request))
                {
                    if (reponse.StatusCode == HttpStatusCode.OK)
                        return Ok(reponse);
                    else
                        return BadRequest(reponse);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequest request)
        {
            try
            {
                using (SignUpOutResponse reponse = await _signUpUseCaseAsync.Execute(request))
                {
                    if (reponse.StatusCode == HttpStatusCode.OK)
                        return Ok(reponse);
                    else
                        return BadRequest(reponse);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
