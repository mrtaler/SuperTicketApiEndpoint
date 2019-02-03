namespace SuperTicketApi.ApiEndpoint
{
    using Autofac.Extensions.DependencyInjection;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using SuperTicketApi.ApiEndpoint.Extension;
    using System.IO;

    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates the web host builder.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {

            return WebHost.CreateDefaultBuilder(args).UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureServices(services => services.AddAutofac())
               // .UseKestrel(/*o => { o.AddServerHeader = true; }*/)
                .UseUrls("http://localhost:9005")
                .ConfigureAppConfiguration(
                (hostingContext, config) =>
                    {
                        config.SetBasePath(Directory.GetCurrentDirectory());
                        config.AddJsonSettingsInProject();
                        config.AddCommandLine(args);
                        config.AddEnvironmentVariables();
                    })
                .UseStartup<Startup>()
                .UseIISIntegration()
                .UseApplicationInsights();
        }
    }
}