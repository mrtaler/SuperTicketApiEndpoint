namespace SuperTicketApi.ApiEndpoint
{
    using System;
    using System.Reflection;

    using Autofac;
    using Autofac.Extensions.DependencyInjection;

    using FluentValidation.AspNetCore;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.AspNetCore.Rewrite;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using Newtonsoft.Json.Serialization;

    using Serilog;
    using Serilog.Events;

    using SuperTicketApi.ApiEndpoint.Extension;
    using SuperTicketApi.Application.MainContext;
    using SuperTicketApi.Domain.MainContext.Mssql;
    using SuperTicketApi.Infrastructure.Crosscutting.Adapter;
    using SuperTicketApi.Infrastructure.Crosscutting.Implementation;
    using SuperTicketApi.Infrastructure.Crosscutting.Implementation.Adapter;

    using ILogger = Serilog.ILogger;

    /// <summary>
    /// The startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        /// <param name="env">
        /// The env.
        /// </param>
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            this.Configuration = configuration;
            string pathSettingsAssembly = Assembly.GetAssembly(typeof(Startup)).Location;
            
            // Core is set up to use the global, statically accessible logger from Serilog.
            // It must be set up in the main entrpoint and does not require a DI container
            // Create a logger with configured sinks, enrichers, and minimum level
            // Serilog's global, statically accessible logger, is set via Log.Logger and can be invoked using the static methods on the Log class.
            // File Sink is commented out and can be replaced with Serilogs vast library of available sinks
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Trace(/*LogEventLevel.Verbose*/)
                .WriteTo.ApplicationInsightsEvents("4f6ea94a-c353-4351-9f71-574900d5b176")
                .WriteTo.RollingFile(
                    "c:\\Logs\\log-{Date}.txt"/*$"{Path.GetDirectoryName(pathSettingsAssembly)}\\Log.txt"*/,
                    LogEventLevel.Verbose,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level}:{EventId} [{SourceContext}] {Message}{NewLine}{Exception}")
                .WriteTo.Console(theme: Serilog.Sinks.SystemConsole.Themes.AnsiConsoleTheme.Code/*LogEventLevel.Debug*/) // <-- This will give us output to our Kestrel console
            // .WriteTo.File("_logs/log-.txt", rollingInterval: RollingInterval.Day) //<-- Write our logs to a local text file with rolling interval configuration
            .CreateLogger();
            Log.Information("The global logger has been configured.");
            Log.Information("Hello, Serilog!");
            
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        /// <returns>
        /// The <see cref="IServiceProvider"/>.
        /// </returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ILogger>().SingleInstance();

            // services.AddSingleton(Log.Logger);
            services.AddSettingsFileMapper(this.Configuration);

            services.AddSwaggerDocumentation();
            services.AddApplicationInsightsTelemetry();

            /* services.AddCors(options =>
                {
                    options.AddPolicy(
                        "AllowAll",
                        builder =>
                            {
                                builder
                                    .AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader();
                            });
                });*/

            /*
             services.AddAuthentication(
                    CookieAuthenticationDefaults.AuthenticationScheme

                // , JwtBearerDefaults.AuthenticationScheme
                ).AddOAuth<GoogleAuthOptions, CustomGoogleHandler>("Google",
                    options =>
                        {

                        })
                .AddOAuth(
                "GitHub",
                options =>
                {


                    options.ClientId = this.configuration.GetSection(nameof(GitHubAuthOptions)).Get<GitHubAuthOptions>().ClientId;
                    options.ClientSecret = this.configuration.GetSection(nameof(GitHubAuthOptions)).Get<GitHubAuthOptions>().ClientSecret;
                    options.CallbackPath = new PathString("/api/Account/callback");

                    options.SignInScheme = JwtBearerDefaults.AuthenticationScheme;

                    options.AuthorizationEndpoint = "https://github.com/login/oauth/authorize";
                    options.TokenEndpoint = "https://github.com/login/oauth/access_token";
                    options.UserInformationEndpoint = "https://api.github.com/user";

                    options.ClaimsIssuer = "OAuth2-Github";
                    options.SaveTokens = true;

                    options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
                    options.ClaimActions.MapJsonKey(ClaimTypes.Name, "login");
                    options.ClaimActions.MapJsonKey("urn:github:name", "name");
                    options.ClaimActions.MapJsonKey(ClaimTypes.Email, "email", ClaimValueTypes.Email);
                    options.ClaimActions.MapJsonKey("urn:github:url", "url");
                    options.Events = new OAuthEvents
                    {
                        // OnRemoteFailure = HandleOnRemoteFailure,
                        OnCreatingTicket = async context =>
                        {
                            var request = new HttpRequestMessage(
                                HttpMethod.Get,
                                context.Options.UserInformationEndpoint);
                            request.Headers.Authorization =
                                new AuthenticationHeaderValue(
                                    "Bearer",
                                    context.AccessToken);
                            request.Headers.Accept.Add(
                                new MediaTypeWithQualityHeaderValue(
                                    "application/json"));

                            var response = await context.Backchannel.SendAsync(
                                               request,
                                               context.HttpContext
                                                   .RequestAborted);
                            response.EnsureSuccessStatusCode();

                            var user = JObject.Parse(
                                await response.Content.ReadAsStringAsync());

                            context.RunClaimActions(user);

                        }
                    };
                });
                */
            services.AddScoped<ITypeAdapterFactory, AutomapperTypeAdapterFactory>();
            TypeAdapterFactory.SetCurrent(services.BuildServiceProvider().GetService<ITypeAdapterFactory>());

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddMvc().AddFluentValidation()
                .AddJsonOptions(
                    options =>
                        {
                            options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                        }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // var rr = this.Configuration.GetSection(nameof(AppConnectionStrings)).Get<AppConnectionStrings>();
            builder.Populate(services);

            // builder.AddMediatR(asss);
            builder.RegisterModule(new MainContextMssqlModule());
            builder.RegisterModule(new SuperTicketApiInfrastructureCrosscuttingModule());
            builder.RegisterModule(new MainContextModule());

            // builder.Register(c => new AppConnectionStrings(c.Resolve<IConfiguration>())).AsSelf();

            // builder.AddMediatR(
            // typeof(AreaPresenterCommandHandler).GetTypeInfo().Assembly);
            var container = builder.Build();
            return new AutofacServiceProvider(container);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">
        /// The <paramref name="app"/>.
        /// </param>
        /// <param name="env">
        /// The env.
        /// </param>
        /// <param name="loggerFactory">
        /// The logger Factory.
        /// </param>
        /// <param name="provider">
        /// The provider.
        /// </param>
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            IApiVersionDescriptionProvider provider)
        {
            /*if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }*/
            
            // loggerFactory.AddSerilog();
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                    {
                        // build a swagger endpoint for each discovered API version
                        foreach (var description in provider.ApiVersionDescriptions)
                        {
                            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                        }
                    });

            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();

            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            
            // app.UseApiKey();
            // app.UseCorrelationId();
            // app.UseConnectionString();
            // app.UseResponseCaching();
            // app.UseCors("AllowAll");
            app.UseMvc();
        }
    }
}
