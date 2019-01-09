//namespace SuperTicketApi.DistributedServices.Seedwork
//{
//    public class ValidationQueryHandlerDecorator<TQuery, TResult>
//        : IQueryHandler<TQuery, TResult>
//        where TQuery : IQuery<TResult>
//    {
//        private readonly IQueryHandler<TQuery, TResult> decorated;

//        public ValidationQueryHandlerDecorator(IQueryHandler<TQuery, TResult> decorated)
//        {
//            this.decorated = decorated;
//        }

//        public TResult Handle(TQuery query)
//        {
//            var validationContext = new ValidationContext(query, null, null);
//            Validator.ValidateObject(query, validationContext,
//                validateAllProperties: true);

//            return this.decorated.Handle(query);
//        }
//    }
//}