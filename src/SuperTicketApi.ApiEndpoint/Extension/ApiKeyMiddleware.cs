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

        private readonly RequestDelegate _next;
        private readonly IApplicationAccessRepository _repo;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiKeyMiddleware"/> class.
        /// </summary>
        public ApiKeyMiddleware(RequestDelegate next, IApplicationAccessRepository repo, ILogger logger)
        {
            this._next = next;
            this._repo = repo;
            this._logger = logger;
        }

        /// <summary>
        /// Invoke the middleware
        /// </summary>
        public Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.Keys.Contains(ApiKeyHeaderName))
            {
                var error = new ApiError("API Key is missing");
                this._logger.ApiError(error);
                return context.WriteErrorAsync(error, HttpStatusCode.BadRequest);
            }
            else if (!this._repo.CheckValidApiKey(context.Request.Headers[ApiKeyHeaderName]))
            {
                var error = new ApiError("Invalid API Key");
                this._logger.ApiError(error);
                return context.WriteErrorAsync(error, HttpStatusCode.Unauthorized);
            }
            else
            {
                return this._next.Invoke(context);
            }
        }
    }
}