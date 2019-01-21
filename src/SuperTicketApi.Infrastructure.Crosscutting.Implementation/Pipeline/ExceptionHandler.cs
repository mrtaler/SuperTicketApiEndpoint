namespace SuperTicketApi.Infrastructure.Crosscutting.Implementation.Pipeline
{
    using MediatR;
    using Serilog;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The exception handler.
    /// </summary>
    /// <typeparam name="TRequest">
    /// </typeparam>
    /// <typeparam name="TResponse">
    /// </typeparam>
    public class ExceptionHandler<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
    {
        /// <summary>
        /// The handle.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <param name="next">
        /// The next.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var response = default(TResponse);

            try
            {
                response = response = await next();
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Log.Error(
                    request.ToString(), response, ex);
            }

            return response;
        }
    }
}