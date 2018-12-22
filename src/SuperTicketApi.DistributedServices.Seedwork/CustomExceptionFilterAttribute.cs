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
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IModelMetadataProvider modelMetadataProvider;

        private readonly ILogger logger;

        public CustomExceptionFilterAttribute(
            IHostingEnvironment hostingEnvironment,
            IModelMetadataProvider modelMetadataProvider,
            ILogger loggerFactory)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.modelMetadataProvider = modelMetadataProvider;

            this.logger =
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

            this.logger.Error(null, exception, result.Value.ToString());

            result.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new BadRequestObjectResult(result);

        }
    }
}
