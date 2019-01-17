namespace SuperTicketApi.Domain.MainContext.Mssql.Repositories
{
    using SuperTicketApi.Domain.MainContext.DTO.IndividualRepositories;
    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.Seedwork;

    /// <summary>
    /// The SeatRepository interface.
    /// </summary>
    public class SeatRepository : GenericRepository<Seat>, ISeatRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SeatRepository"/> class.
        /// </summary>
        /// <param name="connection">
        /// The connection.
        /// </param>
        public SeatRepository(string connection, ISqlHelper sqlHelper)
            : base(connection, sqlHelper)
        {
        }

    }
}