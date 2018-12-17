namespace SuperTicketApi.ApiEndpoint
{
    using System.IO;

    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration(
                    (hostingContext, config) =>
                        {
                            config.SetBasePath(Directory.GetCurrentDirectory());
                            //  config.AddJsonSettingsInProject();
                            config.AddCommandLine(args);
                        }).UseStartup<Startup>().UseIISIntegration()
                .UseApplicationInsights();
    }
}