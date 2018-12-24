namespace SuperTicketApi.ApiEndpoint
{
    using System;
    using System.IO;
    using System.Reflection;

    using Autofac.Extensions.DependencyInjection;

    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Serilog;
    using SuperTicketApi.ApiEndpoint.Extension;

    public class Program
    {
        public static void Main(string[] args)
        {
            string pathSettingsAssembly = Assembly.GetAssembly(typeof(Program)).Location;
           

              CreateWebHostBuilder(args).Build().Run();
          

        }

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