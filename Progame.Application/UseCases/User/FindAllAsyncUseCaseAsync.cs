using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces.Repositories;
using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models;
using Progame.Domain.Models.Response.Answer;
using Progame.Domain.Models.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Progame.Application.UseCases.User
{
    public class FindAllAsyncUseCaseAsync : UseCaseBase, IUseCaseRespAsync<GetAllUsersOutResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public FindAllAsyncUseCaseAsync(IConfiguration configuration,
                                        IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public async Task<GetAllUsersOutResponse> ExecuteAsync()
        {
            try
            {
                var result = await _userRepository.FindAllAsync();

                if (result.Any())
                {
                    var msg = "Data returned with success!";
                    return new GetAllUsersOutResponse(HttpStatusCode.OK, msg, result);
                }
                else
                {
                    var msg = "An error occurred while attempt to find answers! Contact website administrator.";
                    return new GetAllUsersOutResponse(HttpStatusCode.BadRequest, msg, null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
