namespace SuperTicketApi.ApiEndpoint.Extension
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Options;

    using Serilog;
    using Serilog.Context;
    using Serilog.Events;

    using SuperTicketApi.ApiSettings.JsonSettings.CorrelationIdOptions;

    internal class CorrelationIdMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IOptions<CorrelationIdOptions> _options;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CorrelationIdMiddleware"/> class.
        /// </summary>
        public CorrelationIdMiddleware(RequestDelegate next, IOptions<CorrelationIdOptions> options, ILogger logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Invokes the middleware.
        /// </summary>
        public Task Invoke(HttpContext context)
        {
            var options = _options.Value;
            if (!context.Request.Headers.TryGetValue(options.Header, out var correlationId))
            {
                var error = new ApiError("Correlation Id is missing");
                _logger.ApiError(error, LogEventLevel.Error);
                return context.WriteErrorAsync(error);
            }
            else
            {
                context.TraceIdentifier = correlationId;
                LogContext.PushProperty("CorrelationId", correlationId);
                context.Response.OnStarting(
                    () =>
                        {
                            context.Response.Headers.Add(options.Header, new[] { (string)correlationId });
                            return Task.CompletedTask;
                        }
                );
                return _next.Invoke(context);
            }
        }
    }
}