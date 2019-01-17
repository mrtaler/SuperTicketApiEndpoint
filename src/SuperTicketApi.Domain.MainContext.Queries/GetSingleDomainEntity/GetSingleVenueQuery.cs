namespace SuperTicketApi.Domain.MainContext.Queries.GetSingleDomainEntity
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The get single venue query.
    /// </summary>
    public class GetSingleVenueQuery : IRequest<Venue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSingleVenueQuery"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public GetSingleVenueQuery(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public int Id { get; private set; }
    }
}