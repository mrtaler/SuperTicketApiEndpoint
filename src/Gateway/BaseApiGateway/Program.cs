using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace BaseApiGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Run();
        }

        public static IWebHost CreateWebHostBuilder(string[] args)
        {

            var builder = WebHost.CreateDefaultBuilder(args);
            builder
                .UseUrls("http://localhost:9011")
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config
                 .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                 .AddJsonFile("ocelot.json", false, false)
                 .AddEnvironmentVariables();
            })
            .ConfigureServices(s =>
            {
                s.AddSingleton(builder);
                  s.AddOcelot();
        //        s.AddSwaggerForOcelot();
            })
            .Configure(a =>
            {
                //       
               var tt= a.ApplicationServices.GetService<IConfiguration>();
               // a.UseSwaggerForOcelotUI(tt);
                a.UseOcelot().Wait();
            });

            return builder.Build();
        }
    }
}
