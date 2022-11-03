using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces.Repositories;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models.Response.User;
using Progame.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Progame.Domain.Models.Request.User;
using AutoMapper;

namespace Progame.Application.UseCases.User
{
    public class GetUserInfoUseCaseAsync : UseCaseBase, IUseCaseAsync<GetUserInfoRequest, GetUserInfoOutResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public GetUserInfoUseCaseAsync(IConfiguration configuration,
                                IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public async Task<GetUserInfoOutResponse> Execute(GetUserInfoRequest request)
        {
            try
            {
                var result = await _userRepository.FindByIdAsync(request.Id);

                Domain.Entities.User user = new Domain.Entities.User()
                {
                    Id = result.Id,
                    Username = result.Username,
                    Email = result.Email,
                    Experience = result.Experience,
                    IsAdmin = result.IsAdmin,
                    ImgUrl = result.ImgUrl
                };

                if (result != null)
                {
                    var msg = "Data returned with success!";
                    return new GetUserInfoOutResponse(HttpStatusCode.OK, msg, user);
                }
                else
                {
                    var msg = "An error occurred while attempt to find answers! Contact website administrator.";
                    return new GetUserInfoOutResponse(HttpStatusCode.BadRequest, msg, null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
