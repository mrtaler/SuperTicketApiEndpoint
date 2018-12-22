namespace SuperTicketApi.ApiEndpoint.Extension
{
    using System;
    using System.IO;
    using System.Net;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    using Serilog;
    using Serilog.Events;

    /// <summary>
    /// Exception filter for handling unexpected and expected exceptions that passes through to the framework.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly Serilog.ILogger log;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiExceptionFilterAttribute"/> class.
        /// </summary>
        /// <param name="log">
        /// The Logger interface.
        /// </param>
        public ApiExceptionFilterAttribute(Serilog.ILogger log)
        {
            this.log = log;
        }

        /// <inheritdoc />
        public override void OnException(ExceptionContext context)
        {

            ApiError error;
            if (context.Exception is ApiErrorException ex)
            {
                error = new ApiError(ex.Description, ex.GetBaseException());
                this.log.ApiError(error);
            }
            else
            {
                error = new ApiError(context.Exception.Message);
                this.log.ApiError(error, LogEventLevel.Error);
            }

            SetStatusCode(context);
            context.Result = new JsonResult(error);
            base.OnException(context);
        }

        private static void SetStatusCode(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case FileNotFoundException _:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
        }
    }
}