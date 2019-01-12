using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Serilog;

namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.Pipeline
{
    public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        // We run a stopwatch on every request and log a warning for any requests that exceed our threshold.
        private readonly Stopwatch timer;

        public PerformanceBehavior()
        {
            this.timer = new Stopwatch();
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            this.timer.Start();

            var response = await next();

            this.timer.Stop();

            if (this.timer.ElapsedMilliseconds > 500)
            {
                var name = typeof(TRequest).Name;

                // TODO: Add User/Caller Details, or include in Command
                var user ="6";// new User { Id = Guid.NewGuid(), Name = "John Smith" };

                // Uses Serilog's global, statically accessible logger, is set via Log.Logger in the startup/entrypoint of the host solution/project.
                // Sinks, enrichers, and minimum logging level are set up in the entry point.
                // Dependency Injection is not required. We are using a global, statically accessible logger 

                // STRUCTURED LOGGING
                // Use structured logging to capture the full object.
                // Serilog provides the @ destructuring operator to help preserve object structure for our logs.
                Log.Warning("Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@request} {@user}", name, this.timer.ElapsedMilliseconds, request, user);

            }

            return response;
        }
    }
}
