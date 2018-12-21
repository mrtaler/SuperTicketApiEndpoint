namespace SuperTicketApi.DistributedServices.Seedwork.Mediatr
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    public class MediatorPipeline<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IRequestHandler<TRequest, TResponse> _inner;
        private readonly IPreRequestHandler<TRequest>[] _preRequestHandlers;
        private readonly IPostRequestHandler<TRequest, TResponse>[] _postRequestHandlers;

        public MediatorPipeline(
            IRequestHandler<TRequest, TResponse> inner,
            IPreRequestHandler<TRequest>[] preRequestHandlers,
            IPostRequestHandler<TRequest, TResponse>[] postRequestHandlers)
        {
            this._inner = inner;
            this._preRequestHandlers = preRequestHandlers;
            this._postRequestHandlers = postRequestHandlers;
        }

        public Task<TResponse> Handle(TRequest message, CancellationToken cancellationToken)
        {
            foreach (var preRequestHandler in this._preRequestHandlers)
            {
                preRequestHandler.Handle(message);
            }

            var result = this._inner.Handle(message, cancellationToken);

            foreach (var postRequestHandler in this._postRequestHandlers)
            {
                postRequestHandler.Handle(message, result.Result);
            }

            return result;
        }
    }
}