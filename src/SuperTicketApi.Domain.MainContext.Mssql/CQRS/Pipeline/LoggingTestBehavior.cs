namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.Pipeline
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Serilog;

    /// <summary>
    /// The logging behavior.
    /// </summary>
    /// <typeparam name="TRequest">Mediatr TRequest
    /// </typeparam>
    /// <typeparam name="TResponse">Mediatr TResponse
    /// </typeparam>
    public class LoggingTestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        /// <inheritdoc />
        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            Log.Information($"Handling {typeof(TRequest).Name}");
            var response = await next();
            Log.Information($"Handled {typeof(TResponse).Name}");
            return response;
        }
    }
}