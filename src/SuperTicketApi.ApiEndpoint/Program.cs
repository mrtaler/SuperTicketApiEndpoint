namespace SuperTicketApi.ApiEndpoint
{
    using System.IO;
    using System.Reflection;

    using Autofac.Extensions.DependencyInjection;

    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

    using SuperTicketApi.ApiEndpoint.Extension;
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

            return WebHost.CreateDefaultBuilder(args)
          
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureServices(services => services.AddAutofac())
                // .UseKestrel(o=> { o.AddServerHeader = true; }                )
                .ConfigureAppConfiguration(
                (hostingContext, config) =>
                    {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonSettingsInProject();
                    config.AddCommandLine(args);
                })
                .UseStartup<Startup>()
                .UseIISIntegration()
                .UseApplicationInsights();
        }
    }
}