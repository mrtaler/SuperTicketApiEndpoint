namespace SuperTicketApi.ApiEndpoint
{
    using System.IO;

    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

    using SuperTicketApi.ApiEndpoint.Extension;

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseContentRoot(Directory.GetCurrentDirectory())
                //.UseKestrel(options => options.AddServerHeader = false)
                .ConfigureAppConfiguration(
                    (hostingContext, config) =>
                        {
                            config.SetBasePath(Directory.GetCurrentDirectory());
                            config.AddJsonSettingsInProject();
                            config.AddCommandLine(args);
                        }).UseStartup<Startup>()
                .UseIISIntegration()
                .UseApplicationInsights();
    }
}