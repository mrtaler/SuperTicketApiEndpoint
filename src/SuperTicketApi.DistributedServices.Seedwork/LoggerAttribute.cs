namespace SuperTicketApi.DistributedServices.Seedwork
{
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;

    using SuperTicketApi.Infrastructure.Crosscutting.Localization;

    public class LoggerAttribute : ActionFilterAttribute
    {
        private Stopwatch watch;
        private readonly ILogger<LoggerAttribute> logger;

        private ILocalization resources;
        public LoggerAttribute(ILogger<LoggerAttribute> logger)
        {
            this.logger = logger;
            this.resources = LocalizationFactory.CreateLocalResources();
        }

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            this.watch = new Stopwatch();
            this.watch.Start();

            var parameter = actionContext.ActionArguments.FirstOrDefault();
            string logMessage = string.Format(this.resources.GetStringResource(LocalizationKeys.DistributedServices.InfoOnExecuting), actionContext.ActionDescriptor.DisplayName, this.watch.ElapsedMilliseconds);
            object parameterValue = parameter.Value;
            string values = parameterValue != null ? Newtonsoft.Json.JsonConvert.SerializeObject(parameterValue) : null;
            logMessage += string.Format(this.resources.GetStringResource(LocalizationKeys.DistributedServices.InfoParameter), values ?? "/null/");
            this.logger.LogInformation(logMessage);
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            string logMessage = string.Format(this.resources.GetStringResource(LocalizationKeys.DistributedServices.InfoOnExecuted), actionExecutedContext.ActionDescriptor.DisplayName, this.watch.ElapsedMilliseconds);
            this.logger.LogInformation(logMessage);
            this.watch.Stop();
        }
    }
}