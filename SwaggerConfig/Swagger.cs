using Microsoft.Extensions.Configuration;

namespace SwaggerConfig
{
    public class Swagger
    {
        public SwaggerDocs SwaggerDocs { get; }
        public SwaggerEndpoint SwaggerEndpoint { get; }

        public Swagger(IConfiguration configuration)
        {
            OpenApiInfo openApiInfo = new OpenApiInfo(
                configuration.GetSection("Swagger").GetSection("SwaggerDocs").GetSection("OpenApiInfo").GetSection("Title").Value.ToString(),
                configuration.GetSection("Swagger").GetSection("SwaggerDocs").GetSection("OpenApiInfo").GetSection("Version").Value.ToString());

            SwaggerEndpoint = new SwaggerEndpoint(
                configuration.GetSection("Swagger").GetSection("SwaggerEndpoint").GetSection("Url").Value.ToString(),
                configuration.GetSection("Swagger").GetSection("SwaggerEndpoint").GetSection("Name").Value.ToString(),
                configuration.GetSection("Swagger").GetSection("SwaggerEndpoint").GetSection("Version").Value.ToString());

            SwaggerDocs = new SwaggerDocs(
                configuration.GetSection("Swagger").GetSection("SwaggerDocs").GetSection("Name").Value.ToString(),
                openApiInfo, SwaggerEndpoint);
        }
    }
}
