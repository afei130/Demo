using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Expansion.ReadFile
{
    public class ReadFileMethod
    {
        public static IConfiguration Configuration { get; set; }

        static ReadFileMethod()
        {
            Configuration = new ConfigurationBuilder()
                .Add(new JsonConfigurationSource
                {
                    Path = "appsettings.json",
                    ReloadOnChange = true
                }).Build();
        }
    }
}