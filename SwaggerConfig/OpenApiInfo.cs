
namespace SwaggerConfig
{
    public class OpenApiInfo
    {
        public string Title { get; }
        public string Version { get; }

        public OpenApiInfo()
        {

        }

        public OpenApiInfo(string title, string version)
        {
            Title = title;
            Version = version;
        }
    }
}
