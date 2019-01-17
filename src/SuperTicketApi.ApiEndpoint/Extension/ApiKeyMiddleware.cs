namespace SuperTicketApi.ApiEndpoint.Extension
{
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    using Serilog;

    /// <summary>
    /// A middleware for rejecting responses with missing or incorrect API Key
    /// </summary>
    public class ApiKeyMiddleware
    {
        private const string ApiKeyHeaderName = "x-api-key";

        private readonly RequestDelegate next;
        private readonly IApplicationAccessRepository repo;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiKeyMiddleware"/> class.
        /// </summary>
        public ApiKeyMiddleware(RequestDelegate next, IApplicationAccessRepository repo, ILogger logger)
        {
            this.next = next;
            this.repo = repo;
            this.logger = logger;
        }

        /// <summary>
        /// Invoke the middleware
        /// </summary>
        public Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.Keys.Contains(ApiKeyHeaderName))
            {
                var error = new ApiError("API Key is missing");
                this.logger.ApiError(error);
                return context.WriteErrorAsync(error, HttpStatusCode.BadRequest);
            }
            else if (!this.repo.CheckValidApiKey(context.Request.Headers[ApiKeyHeaderName]))
            {
                var error = new ApiError("Invalid API Key");
                this.logger.ApiError(error);
                return context.WriteErrorAsync(error, HttpStatusCode.Unauthorized);
            }
            else
            {
                return this.next.Invoke(context);
            }
        }
    }
}