namespace SuperTicketApi.ApiEndpoint.Extension
{
    using System.IO;
    using System.Reflection;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.PlatformAbstractions;

    using SuperTicketApi.ApiSettings.CorrelationIdOptions;
    using SuperTicketApi.ApiSettings.CustomSettings;
    using SuperTicketApi.ApiSettings.FacebookOptions;
    using SuperTicketApi.ApiSettings.GitHubOptions;
    using SuperTicketApi.ApiSettings.GoogleOptions;
    using SuperTicketApi.ApiSettings.TokenAuthOptions;

    using Swashbuckle.AspNetCore.Swagger;

    public static class SettingsExtension
    {
        /// <summary>
        /// The add json settings in project.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        /// <returns>
        /// The <see cref="IConfigurationBuilder"/>.
        /// </returns>
        public static IConfigurationBuilder AddJsonSettingsInProject(this IConfigurationBuilder builder)
        {
            string pathSettingsAssembly = Assembly.GetAssembly(typeof(CustomSettings)).Location;
            var allJsonSettingsFiles = Directory.GetFiles(
                Path.GetDirectoryName(pathSettingsAssembly),
                "*.json",
                SearchOption.AllDirectories);

            foreach (var sittingFile in allJsonSettingsFiles)
            {
                if (!Path.GetFileNameWithoutExtension(sittingFile).Contains('.'))
                {
                    builder.AddJsonFile(sittingFile, optional: false, reloadOnChange: false);
                }
            }

            return builder;
        }

        /// <summary>
        /// The add settings file mapper.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        /// <returns>
        /// The <see cref="IServiceCollection"/>.
        /// </returns>
        public static IServiceCollection AddSettingsFileMapper(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // add settings file by template services.Configure<your file>(configuration.GetSection(nameof(section in JSON file)));
            services.Configure<CustomSettings>(configuration.GetSection(nameof(CustomSettings)));
            services.Configure<FacebookAuthOptions>(configuration.GetSection(nameof(FacebookAuthOptions)));
            services.Configure<GitHubAuthOptions>(configuration.GetSection(nameof(GitHubAuthOptions)));
            services.Configure<GoogleAuthOptions>(configuration.GetSection(nameof(GoogleAuthOptions)));
            services.Configure<TokenAuthOptions>(configuration.GetSection(nameof(TokenAuthOptions)));
            services.Configure<CorrelationIdOptions>(configuration.GetSection(nameof(CorrelationIdOptions)));
            return services;
        }

        /// <summary>
        /// OpenApi (swagger) documentation for API endpoints
        /// </summary>
        /// <param name="services">service collection</param>
        public static void AddSwaggerDocumentation(this IServiceCollection services)
        {
          //  services.AddApiVersioning(options => options.ReportApiVersions = true);
            services.AddSwaggerGen(
                  c =>
                  {
                      c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                      var filePath = PlatformServices.Default.Application.ApplicationBasePath;
                      var xmlPath = Path.Combine(filePath, "SuperTicketApi.ApiEndpoint.xml");
                      c.IncludeXmlComments(xmlPath);
                  });

            /* services.AddSwaggerGen(
                options =>
                    {
                      /*  var provider = services.BuildServiceProvider()
                            .GetRequiredService<Microsoft.AspNetCore.Mvc.ApiExplorer.IApiVersionDescriptionProvider>();
                        foreach (var description in provider.ApiVersionDescriptions)
                        {*/
            /*  options.SwaggerDoc(
                  "Swagger",
                  new Info
                  {
                      Title = $"API {1}",
                      Version ="1.0"
                  });
              options.DescribeAllEnumsAsStrings();
        //  }

          options.OperationFilter<VersionFilter>();
          options.DocumentFilter<VersionFilter>();
          options.DescribeAllParametersInCamelCase();
      });*/
        }
    }

  /*  /// <summary>
    /// Exception filter for handling unexpected and expected exceptions that passes through to the framework.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger _log;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiExceptionFilterAttribute"/> class.
        /// </summary>
        /// <param name="log">
        /// The Logger interface.
        /// </param>
        public ApiExceptionFilterAttribute(ILogger log)
        {
            _log = log;
        }

        /// <inheritdoc />
        public override void OnException(ExceptionContext context)
        {
            ApiError error;
            if (context.Exception is ApiErrorException ex)
            {
                error = new ApiError(ex.Description, ex.GetBaseException());
                _log.ApiError(error);
            }
            else
            {
                error = new ApiError(context.Exception.Message);
                _log.ApiError(error, LogEventLevel.Error);
            }

            SetStatusCode(context);
            context.Result = new JsonResult(error);
            base.OnException(context);
        }

        private static void SetStatusCode(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case FileNotFoundException _:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
        }
    }*/
}
