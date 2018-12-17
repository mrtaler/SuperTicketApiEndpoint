namespace SuperTicketApi.ApiEndpoint
{
    using FluentValidation.AspNetCore;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using SuperTicketApi.ApiEndpoint.Extension;

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
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
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
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSettingsFileMapper(this.Configuration);
            services.AddSwaggerDocumentation();
          
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
           /* services.AddMvcCore(options =>
            {
             //   options.Filters.Add<ApiExceptionFilterAttribute>();
             //   options.Filters.Add<ValidModelStateFilter>();
            })
                .AddApiExplorer();*/

            #region AddAuthentication





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
            #endregion


           // services.AddRouting(options => options.LowercaseUrls = true);
            services.AddMvc()
                .AddFluentValidation()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();

           // app.UseCors("AllowAll");

          //  app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });

            app.UseMvc();
        }
    }
}
