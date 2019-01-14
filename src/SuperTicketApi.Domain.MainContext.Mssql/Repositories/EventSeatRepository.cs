namespace SuperTicketApi.Domain.MainContext.Mssql.Repositories
{
    using SuperTicketApi.Domain.MainContext.DTO.IndividualRepositories;
    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The EventSeatRepository interface.
    /// </summary>
    public class EventSeatRepository : GenericRepository<EventSeat>, IEventSeatRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventSeatRepository"/> class.
        /// </summary>
        /// <param name="connection">
        /// The connection.
        /// </param>
        public EventSeatRepository(string connection)
              : base(connection)
        {
        }

    }
}