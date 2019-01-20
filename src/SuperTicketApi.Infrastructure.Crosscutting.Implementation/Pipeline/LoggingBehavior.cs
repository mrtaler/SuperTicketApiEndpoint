namespace SuperTicketApi.Infrastructure.Crosscutting.Implementation.Pipeline
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR.Pipeline;

    using Serilog;

    /// <summary>
    /// The logging behavior.
    /// Unlike Performance and Tracing behavior, this behavior will ONLY run as a pre-processor.
    /// Please note the differences in the way the classes are written.
    /// </summary>
    /// <typeparam name="TRequest">Mediatr TRequest
    /// </typeparam>
    public class LoggingBehavior<TRequest> : IRequestPreProcessor<TRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingBehavior{TRequest}"/> class.
        /// </summary>
        public LoggingBehavior()
        {
        }

        /// <inheritdoc />
        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;

            // TODO: Add User/Caller Details, or include in Command
            var user = "Create new entity for user "; // new User { Id = Guid.NewGuid(), Name = "John Smith" };

            // Uses Serilog's global, statically accessible logger, is set via Log.Logger in the startup/entrypoint of the host solution/project.
            // Sinks, enrichers, and minimum logging level are set up in the entry point.
            // Dependency Injection is not required. We are using a global, statically accessible logger.

            // BASIC LOGGING:
            Log.Information("Request: {name} {request} {user}", name, request, user);

            // STRUCTURED LOGGING
            // Use structured logging to capture the full object.
            // Serilog provides the @ destructuring operator to help preserve object structure for our logs.
            Log.Information("Request: {name} {@request} {@user}", name, request, user);

            return Task.CompletedTask;
        }
    }
}
