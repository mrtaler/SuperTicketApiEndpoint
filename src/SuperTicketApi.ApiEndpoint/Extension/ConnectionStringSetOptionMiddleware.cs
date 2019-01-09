using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperTicketApi.ApiEndpoint.Extension
{
    using System.Net;

    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Options;

    using Serilog;
    using Serilog.Events;

    using SuperTicketApi.ApiSettings.JsonSettings;
    using SuperTicketApi.ApiSettings.JsonSettings.ConnectionStrings;

    /// <summary>
    /// 
    /// </summary>
    public class ConnectionStringSetOptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionStringSetOptionMiddleware"/> class.
        /// </summary>
        public ConnectionStringSetOptionMiddleware(
            RequestDelegate next,
            ILogger logger)
        {
            this.next = next;
            this.logger = logger;
        }

        /// <summary>
        /// Invokes the middleware.
        /// </summary>
        public Task Invoke(
            HttpContext context,
            IOptionsSnapshot<AppConnectionStrings> databaseOption)
        {
            var application = context.Request.Query["App"];
            if (string.IsNullOrEmpty(application))
            {
                var error = new ApiError("Tenant is a required request parameter");
                this.logger.ApiError(error);
                return context.WriteErrorAsync(error, HttpStatusCode.BadRequest);
            }

            try
            {
                // todo sector for different connection strings 
               // var path = GetConnectionStringPath(application);
            //    databaseOption.Value.ConnectionString = databaseOption.Value.MssqlConnectionString;
            }
            catch (Exception e)
            {
                var error = new ApiError("Error whilst retrieving connection string", e);
                this.logger.ApiError(error, LogEventLevel.Error);
                return context.WriteErrorAsync(error);
            }

            return this.next.Invoke(context);
        }

        private string GetConnectionStringPath(string organisationCode)
        {
            // todo create multiselect for connection strings for mssql and oracle

            return $"databaseOption.Value.MssqlConnectionString";
        }
    }
}
