//using MediatR;
//using Serilog;
//using System;
//using System.ComponentModel.DataAnnotations;
//using System.Diagnostics;
//using System.Threading;
//using System.Threading.Tasks;

//namespace SuperTicketApi.Infrastructure.Crosscutting.Implementation.Pipeline
//{
//    public class PerformanceBehavior<TRequest, TResponse> :
//        IPipelineBehavior<TRequest, TResponse>
//    {
//        // We run a stopwatch on every request and log a warning for any requests that exceed our threshold.
//        private readonly Stopwatch timer;

//        public PerformanceBehavior()
//        {
//            this.timer = new Stopwatch();
//        }

//        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
//        {
//            Log.Information($"Handling {typeof(TRequest).Name}");
//            this.timer.Start();
//            var response = await next();
//            this.timer.Stop();
//            Log.Information($"Handled {typeof(TResponse).Name}");
//            //if (this.timer.ElapsedMilliseconds > 500)
//            //{

//            // TODO: Add User/Caller Details, or include in Command
//            // var user ="6";// new User { Id = Guid.NewGuid(), Name = "John Smith" };

//            // Uses Serilog's global, statically accessible logger, is set via Log.Logger in the startup/entrypoint of the host solution/project.
//            // Sinks, enrichers, and minimum logging level are set up in the entry point.
//            // Dependency Injection is not required. We are using a global, statically accessible logger 

//            // STRUCTURED LOGGING
//            // Use structured logging to capture the full object.
//            // Serilog provides the @ destructuring operator to help preserve object structure for our logs.
//            Log.Warning($"Running Request: {typeof(TRequest).Name} ({this.timer.ElapsedMilliseconds} milliseconds) {request}");

//            //}

//            return response;
//        }
//    }

//    public class ExceptionHandler<TRequest, TResponse> :
//        IPipelineBehavior<TRequest, TResponse>
//    {

//        public async Task<TResponse> Handle(

//            TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
//        {
//            var response = default(TResponse);

//            try
//            {
//                response = response = await next();
//            }
//            catch (ValidationException)
//            {
//                throw;
//            }
//            catch (Exception ex)
//            {
//                Log.Error(
//                    request.ToString(), response, ex);
//            }

//            return response;
//        }
//    }

//    public class LoggingHandler<TRequest, TResponse> : 
//        IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
//    {
//        private readonly IRequestHandler<TRequest, TResponse> inner;

//        private readonly ILogger<TRequest, TResponse> logger;

//        public LoggingHandler(IRequestHandler<TRequest, TResponse> inner, ILogger<TRequest, TResponse> logger)
//        {
//            this.inner = inner;
//            this.logger = logger;
//        }

//        public TResponse Handle(TRequest request)
//        {
//            this.logger.LogRequestInfo<TRequest, TResponse>(request);

//            var response = this.inner.Handle(request);

//            this.logger.LogResponseInfo(response);

//            return response;
//        }
//    }
//}
////! https://mayuanyang.github.io/Mediator.Net/
////! http://softdevben.blogspot.com/2017/12/using-mediatr-pipeline-with-fluent.html
////! http://thesenilecoder.blogspot.com/2016/12/mediatr-fluentvalidation-and-ninject_23.html
////! https://stackify.com/serilog-tutorial-net-logging/
//// https://github.com/mayuanyang/Mediator.Net
///https://scottbanwart.com/blog/2017/11/mediatr-custom-behavior-logging/