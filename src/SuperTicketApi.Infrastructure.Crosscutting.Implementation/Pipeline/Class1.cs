//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace SuperTicketApi.Infrastructure.Crosscutting.Implementation.Pipeline
//{
//    public class Logger<TRequest, TResponse> : ILogger<TRequest, TResponse> where TRequest : IRequest<TResponse>
//    {
//        public void LogInfo(TRequest request, TResponse response)
//        {
//            this.Log(request, response);
//        }

//        public void LogError(TRequest request, TResponse response, Exception ex)
//        {
//            this.Log(request, response, ex);
//        }

//        public void LogRequestInfo<TRequest, TResponse>(TRequest request) where TRequest : IRequest<TResponse>
//        {
//            ExceptionlessClient.Default
//                .CreateLog("ExceptionLessTest", string.Format("[Request] {0} {1}", request.GetType()), "Info")
//                .AddObject(new RequestLogMessage<TRequest, TResponse> { Request = request })
//                .Submit();
//        }

//        public void LogResponseInfo<TResponse>(TResponse response)
//        {
//            ExceptionlessClient.Default
//                .CreateLog("ExceptionLessTest", string.Format("[Response] {0} {1}", response.GetType()), "Info")
//                .AddObject(new ResponseLogMessage<TResponse> { Response = response })
//                .Submit();
//        }

//        public void LogSql(string sql)
//        {
//            ExceptionlessClient.Default
//                .CreateLog("ExceptionLessTest", sql, "Info")
//                .AddObject(new SqlLogMessage { Sql = sql })
//                .Submit();
//        }

//        private void Log(TRequest request, TResponse response)
//        {
//            this.Log(request, response, null);
//        }

//        private void Log(TRequest request, TResponse response, Exception ex)
//        {
//            if (ex == null)
//            {
//                // log info
//                ExceptionlessClient.Default.CreateLog("ExceptionLessTest", "Info")
//                    .AddObject(new RequestResponseLogMessage<TRequest, TResponse>
//                    {
//                        Request = request,
//                        Response = response,
//                    })
//                    .Submit();
//            }
//            else
//            {
//                // log error
//                ExceptionlessClient.Default.CreateLog("ExceptionLessTest", "Error")
//                    .AddObject(new RequestResponseLogMessage<TRequest, TResponse>
//                    {
//                        Request = request,
//                        Response = response,
//                        Exception = ex
//                    })
//                    .Submit();
//            }
//        }
//    }

//    public interface ILogger<TRequest, TResponse> where TRequest : IRequest<TResponse>
//    {
//        void LogInfo(TRequest request, TResponse response);

//        void LogError(TRequest request, TResponse response, Exception ex);

//        void LogRequestInfo<TRequest, TResponse>(TRequest request) where TRequest : IRequest<TResponse>;

//        void LogResponseInfo<TResponse>(TResponse response);

//        void LogSql(string sql);
//    }
//}
