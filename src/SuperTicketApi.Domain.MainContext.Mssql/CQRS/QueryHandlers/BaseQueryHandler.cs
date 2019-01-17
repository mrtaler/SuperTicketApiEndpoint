namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.QueryHandlers
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO;

    /// <summary>
    /// The base query handler.
    /// </summary>
    public class BaseQueryHandler : BaseHandler
    {
        /// <inheritdoc />
        public BaseQueryHandler(ITabledUnitOfWork unitOfWork, IMediator mediatr)
            : base(unitOfWork, mediatr)
        {
        }
    }
}