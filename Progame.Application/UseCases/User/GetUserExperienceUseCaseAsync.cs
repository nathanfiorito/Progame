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

namespace Progame.Application.UseCases.User
{
    public class GetUserExperienceUseCaseAsync : UseCaseBase, IUseCaseAsync<GetUserExperienceRequest, GetUserExperienceOutResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public GetUserExperienceUseCaseAsync(IConfiguration configuration,
                                        IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public async Task<GetUserExperienceOutResponse> Execute(GetUserExperienceRequest request)
        {
            try
            {
                var result = await _userRepository.GetUserExperience(request.Id);

                if (result != null)
                {
                    var msg = "Data returned with success!";
                    return new GetUserExperienceOutResponse(HttpStatusCode.OK, msg, result.Experience);
                }
                else
                {
                    var msg = "An error occurred while attempt to find answers! Contact website administrator.";
                    return new GetUserExperienceOutResponse(HttpStatusCode.BadRequest, msg, null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
