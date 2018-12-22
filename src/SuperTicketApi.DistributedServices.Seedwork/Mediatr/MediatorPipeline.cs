namespace SuperTicketApi.DistributedServices.Seedwork.Mediatr
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    public class MediatorPipeline<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IRequestHandler<TRequest, TResponse> inner;
        private readonly IPreRequestHandler<TRequest>[] preRequestHandlers;
        private readonly IPostRequestHandler<TRequest, TResponse>[] postRequestHandlers;

        public MediatorPipeline(
            IRequestHandler<TRequest, TResponse> inner,
            IPreRequestHandler<TRequest>[] preRequestHandlers,
            IPostRequestHandler<TRequest, TResponse>[] postRequestHandlers)
        {
            this.inner = inner;
            this.preRequestHandlers = preRequestHandlers;
            this.postRequestHandlers = postRequestHandlers;
        }

        public Task<TResponse> Handle(TRequest message, CancellationToken cancellationToken)
        {
            foreach (var preRequestHandler in this.preRequestHandlers)
            {
                preRequestHandler.Handle(message);
            }

            var result = this.inner.Handle(message, cancellationToken);

            foreach (var postRequestHandler in this.postRequestHandlers)
            {
                postRequestHandler.Handle(message, result.Result);
            }

            return result;
        }
    }
}