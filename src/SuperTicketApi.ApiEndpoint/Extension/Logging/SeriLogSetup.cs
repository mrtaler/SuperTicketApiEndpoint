namespace SuperTicketApi.ApiEndpoint.Extension.Logging
{
    // http://blachniet.com/blog/serilog-good-habits/
    using System.Collections.ObjectModel;
    using System.Data;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Serilog;
    using Serilog.Events;
    using Serilog.Sinks.MSSqlServer;

    /// <summary>
    /// The serilog setup.
    /// </summary>
    public static class SeriLogSetup
    {
        /// <summary>
        /// The configure seri log.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        public static void ConfigureSeriLog(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var columnOptions = new ColumnOptions
            {
                AdditionalDataColumns = new Collection<DataColumn>
                {
                    new DataColumn { DataType = typeof(string), ColumnName = CustomColumn.User.ToString() },
                    new DataColumn { DataType = typeof(string), ColumnName = CustomColumn.Host.ToString() },
                    new DataColumn { DataType = typeof(string), ColumnName = CustomColumn.Environment.ToString() },
                    new DataColumn { DataType = typeof(string), ColumnName = CustomColumn.Other.ToString() },
                }
            };

            columnOptions.Store.Add(StandardColumn.LogEvent);

            services.AddSingleton<ILogger>(
                x => new LoggerConfiguration()
                    .MinimumLevel
                    .Information()
                    .MinimumLevel
                    .Override("Microsoft", LogEventLevel.Warning)
                    .MinimumLevel.Override("System", LogEventLevel.Error)
                    .WriteTo.MSSqlServer(configuration["Serilog:ConnectionString"], configuration["Serilog:TableName"], LogEventLevel.Information, columnOptions: columnOptions, autoCreateSqlTable: true)
                    .CreateLogger());
        }
    }
}
