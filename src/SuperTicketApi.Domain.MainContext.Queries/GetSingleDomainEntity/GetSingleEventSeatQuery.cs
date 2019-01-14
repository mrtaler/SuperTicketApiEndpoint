namespace SuperTicketApi.Domain.MainContext.Queries.GetSingleDomainEntity
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The get single event seat query.
    /// </summary>
    public class GetSingleEventSeatQuery : IRequest<EventSeat>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSingleEventSeatQuery"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public GetSingleEventSeatQuery(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public int Id { get; private set; }
    }
}