namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.CommandHandlers.General
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO;

    /// <summary>
    /// The base command handler.
    /// </summary>
    public class BaseCommandHandler : BaseHandler
    {
        /// <inheritdoc />
        public BaseCommandHandler(ITabledUnitOfWork unitOfWork, IMediator mediatr)
            : base(unitOfWork, mediatr)
        {
        }
    }
}