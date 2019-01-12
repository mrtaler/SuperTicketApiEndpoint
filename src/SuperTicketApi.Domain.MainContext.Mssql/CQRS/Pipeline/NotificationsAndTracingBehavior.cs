using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Serilog;

using SuperTicketApi.Domain.MainContext.DTO.New;

namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.Pipeline
{
    public class NotificationsAndTracingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        // Here we simply trace to our Output window for local Visual Studio debugging.

        // MediatR property and constructor for TracingBehavior are not mandatory in cases where you don't need a dependancy such as MediatR injected.
        // Here we need MediatR in order to send notifications after processing the handler.
        private readonly IMediator mediatr;

        public NotificationsAndTracingBehavior(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            /* ------------------------------------------------------
             * PRE/POST PIPELINE BEHAVIORS
             * ------------------------------------------------------*/
            // Sends trace statements to diagnostics/output window in Visual Studio during debugging
            Trace.WriteLine(string.Concat("Handling: PreProcessor for ", typeof(TRequest).Name));
            var response = await next(); // <-- Send request to the requested handler
            Trace.WriteLine(string.Concat("Handled: PostProcessor for ", typeof(TRequest).Name));

            /* ------------------------------------------------------
             * NOTIFICATIONS (Pub/Sub)
             * ------------------------------------------------------*/
            // Send test 'ping' notification after all handlers completed processing.
            var ping = new Ping { Message = "Ping..." };
            await this.mediatr.Publish(ping);

            /* -----------------------------------------------------
             * ^ PUBLISHING STRATEGY ^
             * ------------------------------------------------------
             * The default implementation of Publish, loops trough the notification handlers and awaits each one.
             * This makes sure each handler is run after one another, while each call to 'Handle' is run
             * asynchronously. Depending on your use-case for publishing notifications, you might need a
             * different strategy for handling the notifications. Maybe you want to publish all notifications
             * in parallel, or wrap each notification handler with your own exception handling logic.
             *--------------------------------------------------/




            /* ------------------------------------------------------
             * ADDITIONAL NOTES
             * ------------------------------------------------------*/
            // It is bad practice to place too much (if any) of the examples below within the pipeline.
            // It would likely be cleaner to include this logging within the commands themselves.
            // However it is important to point out the type of control you have within the MediatR pipeline
            // -----------------------------------------------------------

            // You can inject pipeline functionality on specific result status...
            if (typeof(TResponse).Name == "CommandResponse")
            {
                if (!(response as CommandResponse).IsSuccess)
                {
                    Log.Warning("{name} attempted execution with issues: {message}", typeof(TRequest).Name, (response as CommandResponse).Message);
                }
            }


            // ...As well as on specific command types with a specific result scenario:
            if (typeof(TRequest).Name == "CreateAccountCommand")
            {
                if (!(response as CommandResponse).IsSuccess && (response as CommandResponse).ValidationErrors != null)
                {


                    // BASIC LOGGING
                    Log.Warning("{name} executed with the following validation issues: {errors}", typeof(TRequest).Name, (response as CommandResponse).ValidationErrors);

                    // STRUCTURED LOGGING:
                    // Use structured logging to capture the full object, it's properties and associated data:
                    // Serilog provides the @ destructuring operator to help preserve object structure for our logs.
                    Log.Warning("{name} executed with the following validation issues: {@errors}", typeof(TRequest).Name, (response as CommandResponse).ValidationErrors);
                }
            }



            return response;
        }
    }

    public class Ping : INotification
    {
        public string Message { get; set; }
    }

    public class Pong1 : INotificationHandler<Ping>
    {
        public Task Handle(Ping notification, CancellationToken cancellationToken)
        {
            // Sends trace statements to diagnostics/output window in Visual Studio during debugging
            Trace.WriteLine(string.Concat("Pong 1: ", notification.Message));

            // Log via Serilog:
            Log.Information(string.Concat("Pong 1 Notification Called: ", notification.Message));

            return Task.CompletedTask;
        }
    }
    public class Pong2 : INotificationHandler<Ping>
    {
        public Task Handle(Ping notification, CancellationToken cancellationToken)
        {
            // Sends trace statements to diagnostics/output window in Visual Studio during debugging
            Trace.WriteLine(string.Concat("Pong 2: ", notification.Message));

            // Log via Serilog:
            Log.Information(string.Concat("Pong 2 Notification Called: ", notification.Message));

            return Task.CompletedTask;
        }
    }

}/// https://github.com/asc-lab/dotnetcore-microservices-poc
