namespace SuperTicketApi.ApiEndpoint.Controllers.Base
{
    using FluentValidation.Results;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json.Linq;
    using SuperTicketApi.Application.MainContext.Cqrs;
    using System.Linq;

    /// <summary>
    /// Base controller with mediatr
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public BaseController(IMediator mediator) => this.Mediator = mediator;

        /// <summary>
        /// Gets or sets the mediator.
        /// In process messaging service. Glue between layers of the application
        /// </summary>
        protected IMediator Mediator { get; set; }


        private string ValidationErrorSelector(ValidationFailure failure)
        {
            var retResult = JObject.FromObject(
            new
            {
                failure.PropertyName,
                failure.AttemptedValue,
                failure.ErrorMessage,
                failure.CustomState,
                failure.ErrorCode,
                PlaceHolder = new
                {
                    propertyName =
                        failure.FormattedMessagePlaceholderValues["PropertyName"],
                    propertyValue =
                        failure.FormattedMessagePlaceholderValues["PropertyValue"]
                }
            });

            return retResult.ToString();
        }

        protected ObjectResult GetResult(ApplicationCommandResponse response)
        {
            if (response.IsSuccess)
            {
                return new ObjectResult(new
                {
                    Success = response.IsSuccess,
                    NewEntity = response.Object,
                });
            }

            return new ObjectResult(new
            {
                Success = response.IsSuccess,
                Error = response.Message,
                ValidationError = response.ValidationErrors.Select(ValidationErrorSelector)
            });
        }
    }
}