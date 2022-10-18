using Microsoft.AspNetCore.Http;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Progame.Domain.Models.Response;
using Progame.Domain.Models.Response.Error;
using System.Net;
using Newtonsoft.Json;

namespace Progame.WebApi
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            ErrorResponse errorResponse;
            if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                errorResponse = new ErrorResponse(HttpStatusCode.InternalServerError.ToString(), $"{ex.Message} {ex?.StackTrace}");
            }
            else
            {
                errorResponse = new ErrorResponse(HttpStatusCode.InternalServerError.ToString(), "Ocorreu um erro interno;");
            }

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = JsonConvert.SerializeObject(errorResponse);
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }
}