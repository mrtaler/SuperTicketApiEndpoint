namespace SuperTicketApi.Domain.MainContext.Queries.GetSingleDomainEntity
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The get single layout query.
    /// </summary>
    public class GetSingleLayoutQuery : IRequest<Layout>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSingleLayoutQuery"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public GetSingleLayoutQuery(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public int Id { get; private set; }
    }
}