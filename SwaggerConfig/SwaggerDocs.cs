
namespace SwaggerConfig
{
    public class SwaggerDocs
    {
        public string Name { get; }
        public OpenApiInfo OpenApiInfo { get; }
        public SwaggerEndpoint SwaggerEndpoint { get; }

        public SwaggerDocs()
        {
        }

        public SwaggerDocs(string name, OpenApiInfo openApiInfo, SwaggerEndpoint swaggerEndpoint)
        {
            Name = name;
            OpenApiInfo = openApiInfo;
            SwaggerEndpoint = swaggerEndpoint;
        }
    }
}
