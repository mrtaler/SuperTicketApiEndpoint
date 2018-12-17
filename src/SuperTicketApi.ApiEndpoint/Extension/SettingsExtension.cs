namespace SuperTicketApi.ApiEndpoint.Extension
{
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.PlatformAbstractions;
    using SuperTicketApi.ApiSettings.CorrelationIdOptions;
    using SuperTicketApi.ApiSettings.CustomSettings;
    using SuperTicketApi.ApiSettings.FacebookOptions;
    using SuperTicketApi.ApiSettings.GitHubOptions;
    using SuperTicketApi.ApiSettings.GoogleOptions;
    using SuperTicketApi.ApiSettings.TokenAuthOptions;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using Swashbuckle.AspNetCore.Swagger;
    using Swashbuckle.AspNetCore.SwaggerGen;

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
            services.AddApiVersioning(options => options.ReportApiVersions = true);
            services.AddMvcCore().AddVersionedApiExplorer(
                options =>
                    {
                        options.GroupNameFormat = "'v'VVV";

                        // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                        // can also be used to control the format of the API version in route templates
                        options.SubstituteApiVersionInUrl = true;
                    });

            // services.AddSwaggerGen(
            /*  options =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                    var filePath = PlatformServices.Default.Application.ApplicationBasePath;
                    var xmlPath = Path.Combine(filePath, "SuperTicketApi.ApiEndpoint.xml");
                    c.IncludeXmlComments(xmlPath);
                });*/

            services.AddSwaggerGen(
               options =>
                   {
                       using (var serviceProvider = services.BuildServiceProvider())
                       {
                           var provider = serviceProvider.GetRequiredService<IApiVersionDescriptionProvider>();
                           foreach (var description in provider.ApiVersionDescriptions)
                           {
                               options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
                           }
                       }

                       options.OperationFilter<SwaggerDefaultValues>();
                       options.IncludeXmlComments(XmlCommentsFilePath);
                       options.DescribeAllParametersInCamelCase();
                   });
        }

        static string XmlCommentsFilePath
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }

        static Info CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new Info()
                           {
                               Title = $"Sample API {description.ApiVersion}",
                               Version = description.ApiVersion.ToString(),
                               Description = "A sample application with Swagger, Swashbuckle, and API versioning.",
                               Contact = new Contact() { Name = "Bill Mei", Email = "bill.mei@somewhere.com" },
                               TermsOfService = "Shareware",
                               License = new License() { Name = "MIT", Url = "https://opensource.org/licenses/MIT" }
                           };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }

    public class SwaggerDefaultValues : IOperationFilter
    {
        /// <summary>
        /// Applies the filter to the specified operation using the given context.
        /// </summary>
        /// <param name="operation">The operation to apply the filter to.</param>
        /// <param name="context">The current operation filter context.</param>
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                return;
            }

            // REF: https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/412
            // REF: https://github.com/domaindrivendev/Swashbuckle.AspNetCore/pull/413
            foreach (var parameter in operation.Parameters.OfType<NonBodyParameter>())
            {
                var description = context.ApiDescription.ParameterDescriptions.First(p => p.Name == parameter.Name);
                var routeInfo = description.RouteInfo;

                if (parameter.Description == null)
                {
                    parameter.Description = description.ModelMetadata?.Description;
                }

                if (routeInfo == null)
                {
                    continue;
                }

                if (parameter.Default == null)
                {
                    parameter.Default = routeInfo.DefaultValue;
                }

                parameter.Required |= !routeInfo.IsOptional;
            }
        }
    }
}