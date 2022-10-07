using Progame.Domain.Interfaces.UseCases;
using Progame.Domain.Models.Request.Module;
using Progame.Domain.Models.Response.Module;
using Progame.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progame.Domain.Models.Response.QuestionType;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Progame.Domain.Interfaces.Repositories;
using System.Net;

namespace Progame.Application.UseCases.QuestionType
{
    public class GetAllQuestionTypesUseCaseRespAsync : UseCaseBase, IUseCaseRespAsync<GetAllQuestionTypeResponse>
    {
        private readonly IQuestionTypeRepository _questionTypeRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public GetAllQuestionTypesUseCaseRespAsync(IQuestionTypeRepository questionTypeRepository,
                                IMapper mapper,
                                IConfiguration configuration)
        {
            _questionTypeRepository = questionTypeRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<GetAllQuestionTypeResponse> ExecuteAsync()
        {
            try
            {
                GetAllQuestionTypeResponse OutResponse = new GetAllQuestionTypeResponse();

                var result = await _questionTypeRepository.FindAllAsync();

                if (result.Count() > 0)
                {
                    OutResponse.StatusCode = HttpStatusCode.OK;
                    OutResponse.Data = result;
                    OutResponse.Mensagem = "Dados retornados com sucesso!";
                }
                else
                {
                    OutResponse.StatusCode = HttpStatusCode.NoContent;
                    OutResponse.Data = null;
                    OutResponse.Mensagem = "Não foi encontrado nenhum resultado com os parametros informados.";
                }
                return OutResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
