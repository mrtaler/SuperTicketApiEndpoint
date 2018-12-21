using System;

namespace SuperTicketApi.DistributedServices.Seedwork
{
    using System.Net;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    using Serilog;

    using SuperTicketApi.Application.Seedwork;

    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IModelMetadataProvider _modelMetadataProvider;

        private readonly ILogger _logger;

        public CustomExceptionFilterAttribute(
            IHostingEnvironment hostingEnvironment,
            IModelMetadataProvider modelMetadataProvider,
            ILogger loggerFactory)
        {
            this._hostingEnvironment = hostingEnvironment;
            this._modelMetadataProvider = modelMetadataProvider;

            this._logger =
                loggerFactory
                    .ForContext<CustomExceptionFilterAttribute>();
        }

        public override void OnException(ExceptionContext context)
        {
            // if (!_hostingEnvironment.IsDevelopment())
            // {
            // // do nothing
            // return;
            // }
            var exception = context.Exception;
            var message = exception.Message;

            if (exception is ApplicationValidationErrorsException)
            {
                var validationErrors = ((ApplicationValidationErrorsException)exception).ValidationErrors;

                if (validationErrors != null)
                {
                    foreach (var error in validationErrors)
                    {
                        message += Environment.NewLine + error;
                    }
                }
            }

            var controller = context.ActionDescriptor.RouteValues["controller"];
            var action = context.ActionDescriptor.RouteValues["action"];
            var result = new JsonResult(new { controller, action, message });

            this._logger.Error(null, exception, result.Value.ToString());

            result.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new BadRequestObjectResult(result);

        }
    }
}
