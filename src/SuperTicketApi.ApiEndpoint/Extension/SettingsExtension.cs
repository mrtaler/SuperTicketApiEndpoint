namespace SuperTicketApi.ApiEndpoint.Extension
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using Autofac;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.PlatformAbstractions;

    using SuperTicketApi.ApiSettings.JsonSettings.ConnectionStrings;
    using SuperTicketApi.ApiSettings.JsonSettings.CorrelationIdOptions;
    using SuperTicketApi.ApiSettings.JsonSettings.CustomSettings;
    using SuperTicketApi.ApiSettings.JsonSettings.FacebookOptions;
    using SuperTicketApi.ApiSettings.JsonSettings.GitHubOptions;
    using SuperTicketApi.ApiSettings.JsonSettings.GoogleOptions;
    using SuperTicketApi.ApiSettings.JsonSettings.TokenAuthOptions;

    using Swashbuckle.AspNetCore.Swagger;

    /// <summary>
    /// The settings extension.
    /// </summary>
    public static class SettingsExtension
    {
        /// <summary>
        /// The add json settings in project.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        /// <param name="env">Environment Var</param>
        /// <returns>
        /// The <see cref="IConfigurationBuilder"/>.
        /// </returns>
        public static IConfigurationBuilder AddJsonSettingsInProject(
            this IConfigurationBuilder builder,
            IHostingEnvironment env)
        {
            /*var solutionPath = Path.GetDirectoryName(Environment.GetEnvironmentVariable("SolutionPath"));
            var pathSettings = Path.Combine(solutionPath, @"src\SuperTicketApi.ApiSettings\JsonSettings\");

            var allJsonSettingsFiles = Directory.GetFiles(
                pathSettings,
                "*.json",
                SearchOption.AllDirectories);

            var envJsonFiles = allJsonSettingsFiles.Where(x => Path.GetFileName(x).Contains(env.EnvironmentName));
            var usualJson = allJsonSettingsFiles.Where(x => Path.GetFileName(x).Split('.').Length != 3);
            var allJsonSettings = envJsonFiles.Union(usualJson);
           
              foreach (var sittingFile in allJsonSettings)
              {
                  builder.AddJsonFile(sittingFile, optional: false, reloadOnChange: false);
              }
              */

            string pathSettingsAssembly = Assembly.GetAssembly(typeof(CustomSettings)).Location;

            // JsonSettings
            var allJsonSettingsFiles = Directory.GetFiles(
                Path.Combine(Path.GetDirectoryName(pathSettingsAssembly), "JsonSettings"),
                "*.json",
                SearchOption.AllDirectories);

            foreach (var sittingFile in allJsonSettingsFiles)
            {
                builder.AddJsonFile(sittingFile, optional: false, reloadOnChange: false);
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
            services.Configure<AppConnectionStrings>(configuration.GetSection(nameof(AppConnectionStrings)));

            return services;
        }

        /// <summary>
        /// OpenApi (swagger) documentation for API endpoints
        /// </summary>
        /// <param name="services">service collection</param>
        public static void AddSwaggerDocumentation(this IServiceCollection services)
        {
            /*services.AddMvcCore(options =>
            {
                options.Filters.Add<ApiExceptionFilterAttribute>();
                options.Filters.Add<ValidModelStateFilter>();
            }).AddApiExplorer();*/
            services.AddVersionedApiExplorer(
                options =>
                    {
                        options.GroupNameFormat = "'v'VVV";

                        // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                        // can also be used to control the format of the API version in route templates
                        options.SubstituteApiVersionInUrl = true;
                    });


            services.AddApiVersioning(options => options.ReportApiVersions = true);
            services.AddSwaggerGen(
               options =>
                    {
                        // resolve the IApiVersionDescriptionProvider service
                        // note: that we have to build a temporary service provider here because one has not been created yet
                        using (var serviceProvider = services.BuildServiceProvider())
                        {
                            var provider = serviceProvider.GetRequiredService<IApiVersionDescriptionProvider>();

                            // add a swagger document for each discovered API version
                            // note: you might choose to skip or document deprecated API versions differently
                            foreach (var description in provider.ApiVersionDescriptions)
                            {
                                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
                            }
                        }

                        options.OperationFilter<SwaggerDefaultValues>();
                        options.IncludeXmlComments(XmlCommentsFilePath);

                        // options.DescribeAllParametersInCamelCase();
                    });
        }

        /// <summary>
        /// Gets the xml comments file path.
        /// </summary>
        private static string XmlCommentsFilePath
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }

        /// <summary>
        /// The create info for api version.
        /// </summary>
        /// <param name="description">
        /// The description.
        /// </param>
        /// <returns>
        /// The <see cref="Info"/>.
        /// </returns>
        private static Info CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new Info()
            {
                Title = $"Sample API {description.ApiVersion}",
                Version = description.ApiVersion.ToString(),
                Description = "A Super Ticket Api Endpoint with Swagger, Swashbuckle, and API versioning.",
                Contact = new Contact() { Name = "Siarhei Linkevich", Email = "mrtaler@me.com" },
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


}
