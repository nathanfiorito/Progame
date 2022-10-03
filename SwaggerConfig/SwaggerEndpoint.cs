
namespace SwaggerConfig
{
    public class SwaggerEndpoint
    {
        public string Url { get; }
        public string Name { get; }
        public string Version { get; }

        public SwaggerEndpoint()
        {
        }

        public SwaggerEndpoint(string url, string name, string version)
        {
            Url = url;
            Name = name;
            Version = version;
        }
    }
}
