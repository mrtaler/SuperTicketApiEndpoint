using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace ApiGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHostBuilder builder = new WebHostBuilder();
            builder.ConfigureServices(s =>
            {
                s.AddSingleton(builder);
            });

            builder.UseKestrel()
                   .UseContentRoot(Directory.GetCurrentDirectory())
                   .UseStartup<Startup>()
                    .ConfigureAppConfiguration((config) =>
                    {
                        config.AddJsonFile("ocelot.json");
                        config.AddEnvironmentVariables();
                    })
                   .UseUrls("http://localhost:9000");

            var host = builder.Build();
            host.Run();

        }
    }
}
