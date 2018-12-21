namespace SuperTicketApi.ApiEndpoint.Extension
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    using Serilog;

    public class ValidModelStateFilter : IActionFilter
    {
        private readonly ILogger _log;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidModelStateFilter"/> class.
        /// </summary>
        public ValidModelStateFilter(ILogger log)
        {
            this._log = log;
        }

        /// <inheritdoc/>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // nothing to do
        }

        /// <inheritdoc/>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var modelState = context.ModelState;
            if (!modelState.IsValid)
            {
                var errors = modelState.Values.SelectMany(x => x.Errors);
                var error = new ApiError(
                    $"Model is not valid in {string.Join(", ", context.ActionDescriptor.RouteValues.Values)}: {string.Join("\n", errors.Select(e => e.ErrorMessage))}");
                this._log.ApiError(error);
                context.Result = new BadRequestObjectResult(error);
            }
        }
    }
}