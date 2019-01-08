using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Sinks.Seq;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SuperTicketApi.ApiEndpoint.Logging
{
    public static class SeriLogSetup
    {
        // http://blachniet.com/blog/serilog-good-habits/
        public static void ConfigureSeriLog(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            //为log添加自定义列
            var columnOptions = new ColumnOptions
            {
                AdditionalDataColumns = new Collection<DataColumn>
                {
                    new DataColumn {DataType = typeof (string), ColumnName = CustomColumn.User.ToString()},
                    new DataColumn {DataType = typeof (string), ColumnName = CustomColumn.Host.ToString()},
                    new DataColumn {DataType = typeof (string), ColumnName = CustomColumn.Enviornment.ToString()},
                    new DataColumn {DataType = typeof (string), ColumnName = CustomColumn.Other.ToString()},
                }
            };

            columnOptions.Store.Add(StandardColumn.LogEvent);

            //注入serilog
            services.AddSingleton<ILogger>(x => new LoggerConfiguration()
                                               .MinimumLevel.Information()
                                               .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                                               .MinimumLevel.Override("System", LogEventLevel.Error)
                                               .WriteTo.MSSqlServer(configuration["Serilog:ConnectionString"],
                                                                    configuration["Serilog:TableName"],
                                                                    LogEventLevel.Information,
                                                                    columnOptions: columnOptions, autoCreateSqlTable: true)
                                               .WriteTo.Seq("http://localhost:5341")
                                               .CreateLogger());
        }
    }
}
