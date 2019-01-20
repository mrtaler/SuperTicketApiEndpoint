//using MediatR;
//using System;

//namespace SuperTicketApi.Infrastructure.Crosscutting.Implementation.Pipeline
//{
//    public class DatabaseHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
//    {
//        private readonly IRequestHandler<TRequest, TResponse> inner;
//        private readonly Context db;
//        private readonly ILogger<TRequest, TResponse> logger;

//        public DatabaseHandler(IRequestHandler<TRequest, TResponse> inner, Context db, ILogger<TRequest, TResponse> logger)
//        {
//            this.inner = inner;
//            this.db = db;
//            this.logger = logger;
//        }

//        public TResponse Handle(TRequest request)
//        {
//            TResponse response;
//            using (var transaction = this.db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
//            {
//                this.db.Database.Log = (log) =>
//                    {
//                        if (log != Environment.NewLine)
//                        {
//                            this.logger.LogSql(log);
//                        }
//                    };

//                response = this.inner.Handle(request);

//                this.db.SaveChanges();

//                transaction.Commit();
//            }

//            return response;
//        }
//    }
//}
