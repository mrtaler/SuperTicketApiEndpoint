namespace SuperTicketApi.ApiEndpoint.Extension
{
    using Microsoft.AspNetCore.Builder;

    /// <summary>
    /// Extensions for conveniently enabling middlewares.
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Enable ApiKeyValidation middleware
        /// </summary>
        public static IApplicationBuilder UseApiKey(this IApplicationBuilder app)
        {
            app.UseMiddleware<ApiKeyMiddleware>();
            return app;
        }

        /// <summary>
        /// Enable CorrelationIdValidation middleware
        /// </summary>
        public static IApplicationBuilder UseCorrelationId(this IApplicationBuilder app)
        {
            app.UseMiddleware<CorrelationIdMiddleware>();
            return app;
        }

        /// <summary>
        /// Enable <see cref="ConnectionStringSetOptionMiddleware"/> middleware
        /// </summary>
        public static IApplicationBuilder UseConnectionString(this IApplicationBuilder app)
        {
            app.UseMiddleware<ConnectionStringSetOptionMiddleware>();
            return app;
        }
    }
}