﻿using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.Pipeline
{
    using MediatR;

    using Serilog.Core;

    // Unlike Performance and Tracing behavior, this behavior will ONLY run as a pre-processor.
    // Please note the differences in the way the classes are written.

    public class LoggingBehavior<TRequest> : IRequestPreProcessor<TRequest>
    {
        public LoggingBehavior()
        {
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;

            // TODO: Add User/Caller Details, or include in Command
            var user = "Create new entity for user ";//new User { Id = Guid.NewGuid(), Name = "John Smith" };

            // Uses Serilog's global, statically accessible logger, is set via Log.Logger in the startup/entrypoint of the host solution/project.
            // Sinks, enrichers, and minimum logging level are set up in the entry point.
            // Dependency Injection is not required. We are using a global, statically accessible logger.

            // BASIC LOGGING:
            Log.Information("Request: {name} {request} {user}", name, request, user);

            // STRUCTURED LOGGING
            // Use structured logging to capture the full object.
            // Serilog provides the @ destructuring operator to help preserve object structure for our logs.
            Log.Information("Request: {name} {@request} {@user}", name, request, user);

            return Task.CompletedTask;
        }
    }

    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            Log.Information($"Handling {typeof(TRequest).Name}");
            var response = await next();
            Log.Information($"Handled {typeof(TResponse).Name}");
            return response;
        }
    }
}
