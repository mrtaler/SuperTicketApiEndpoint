namespace SuperTicketApi.Domain.MainContext.Queries.GetSingleDomainEntity
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The get single event area query.
    /// </summary>
    public class GetSingleEventAreaQuery : IRequest<EventArea>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSingleEventAreaQuery"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public GetSingleEventAreaQuery(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public int Id { get; private set; }
    }
}