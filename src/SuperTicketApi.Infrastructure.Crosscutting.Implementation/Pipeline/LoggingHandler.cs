namespace SuperTicketApi.Infrastructure.Crosscutting.Implementation.Pipeline
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Serilog;

    public class LoggingHandler<TRequest, TResponse> :
        IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IRequestHandler<TRequest, TResponse> inner;

        public LoggingHandler(IRequestHandler<TRequest, TResponse> inner)
        {
            this.inner = inner;
        }

        public async Task<TResponse> Handle(TRequest request,CancellationToken ct)
        {
            Log.Information(request.ToString());
            // this.logger.LogRequestInfo<TRequest, TResponse>(request);

            var response = this.inner.Handle(request,ct);

            Log.Information(response.ToString());

            return await response;
        }
    }
}