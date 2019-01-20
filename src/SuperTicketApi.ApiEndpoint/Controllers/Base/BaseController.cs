namespace SuperTicketApi.ApiEndpoint.Controllers.Base
{
    using FluentValidation.Results;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using SuperTicketApi.Application.MainContext.Cqrs;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Base controller with mediatr
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Produces("application/json")]
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


        private ApiValidationError ValidationErrorSelector(ValidationFailure failure)
        {
            var holder = new Dictionary<string, string>()
            {
                ["PropertyName"] = failure.FormattedMessagePlaceholderValues["PropertyName"].ToString(),
                ["PropertyValue"] = failure.FormattedMessagePlaceholderValues["PropertyValue"].ToString()
            };
            var retResult =
        new ApiValidationError
        {
            PropertyName = failure.PropertyName,
            AttemptedValue = failure.AttemptedValue?.ToString(),
            ErrorMessage = failure.ErrorMessage,
            CustomState = failure.CustomState?.ToString(),
            ErrorCode = failure.ErrorCode,
            PlaceHolder = holder
        };



            /*  = JsonConvert.SerializeObject(
              new
              {
                  propertyName =
                      ,
                  propertyValue =


              }, Formatting.None)*/

            return retResult;
        }

        protected JsonResult GetResult(ApplicationCommandResponse response)
        {
            if (response.IsSuccess)
            {
                return new JsonResult(new
                {
                    Success = response.IsSuccess,
                    NewEntity = response.Object,
                });
            }

            return new JsonResult(new
            {
                Success = response.IsSuccess,
                Error = response.Message,
                ValidationError = response.ValidationErrors.Select(ValidationErrorSelector)
            });
        }

        protected class ApiValidationError
        {
            public ApiValidationError()
            {
                PlaceHolder = new Dictionary<string, string>();
            }
            public string PropertyName { get; set; }
            public string AttemptedValue { get; set; }
            public string ErrorMessage { get; set; }
            public string CustomState { get; set; }
            public string ErrorCode { get; set; }
            public Dictionary<string, string> PlaceHolder { get; set; }
        }


    }
}