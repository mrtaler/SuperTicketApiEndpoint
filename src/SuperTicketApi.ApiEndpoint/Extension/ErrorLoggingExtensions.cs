namespace SuperTicketApi.ApiEndpoint.Extension
{

    using Serilog;
    using Serilog.Events;

    /// <summary>
    /// Extensions for logging errors.
    /// </summary>
    public static class ErrorLoggingExtensions
    {
        /// <summary>
        /// Log an <see cref="ApiError"/> using Serilog.
        /// </summary>
        /// <param name="logger">
        /// The logger interface.
        /// </param>
        /// <param name="error">
        /// The Api error.
        /// </param>
        /// <param name="level">
        /// The log level.
        /// </param>
        public static void ApiError(this ILogger logger, ApiError error, LogEventLevel level = LogEventLevel.Warning)
        {
            var errorLogger = logger.ForContext("ErrorId", error.Id);
            errorLogger.Write(level, error.GetException(), error.Description);
        }
    }
}