namespace SuperTicketApi.Domain.MainContext.Queries.GetSingleDomainEntity
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The get single seat query.
    /// </summary>
    public class GetSingleSeatQuery : IRequest<Seat>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSingleSeatQuery"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public GetSingleSeatQuery(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public int Id { get; private set; }
    }
}