using System.Collections.Generic;

namespace SuperTicketApi.Application.MainContext.Cqrs
{
    using FluentValidation;
    using FluentValidation.Results;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;


    public interface IValidated
    {
        bool AlreadyValidated { get; set; }
    }


    public class ApplicationValidatorBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, IValidated
        where TResponse : class
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly IRequestHandler<TRequest, TResponse> _inner;

        public ApplicationValidatorBehavior(
            IRequestHandler<TRequest, TResponse> inner,
            IEnumerable<IValidator<TRequest>> validators)
        {
            _inner = inner;
            _validators = validators;
        }

        /// <inheritdoc />
        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {

                var context = new ValidationContext(request);

                var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();
                request.AlreadyValidated = true;

                return failures.Any()
                ? await  Errors(failures)
                : await next();
        }

        private Task<TResponse> Errors(IEnumerable<ValidationFailure> failures)
        {

            var response = new ApplicationCommandResponse
            {
                Message = "One or more validation errors occurred.",
            };

            foreach (var failure in failures)
            {
                response.ValidationErrors.Add(failure);
            }

            return Task.FromResult(response as TResponse);
        }
    }
}
/*
 * http://iamnotmyself.com/2015/06/04/a-non-trivial-example-of-mediatr-usage/
 */
