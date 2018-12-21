﻿namespace SuperTicketApi.DistributedServices.Seedwork.Mediatr
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    public class LoggingDecorator<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IRequestHandler<TRequest, TResponse> _decorated;

        public LoggingDecorator(IRequestHandler<TRequest, TResponse> decorated)
        {
            this._decorated = decorated;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var result = this._decorated.Handle(request, cancellationToken);
            return result;
        }
    }
}