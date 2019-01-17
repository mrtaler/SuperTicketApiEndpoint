namespace SuperTicketApi.Domain.MainContext.Mssql.Repositories
{
    using SuperTicketApi.Domain.MainContext.DTO.IndividualRepositories;
    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.Seedwork;

    /// <summary>
    /// The LayoutRepository interface.
    /// </summary>
    public class LayoutRepository : GenericRepository<Layout>, ILayoutRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutRepository"/> class.
        /// </summary>
        /// <param name="connection">
        /// The connection.
        /// </param>
        public LayoutRepository(string connection, ISqlHelper sqlHelper)
            : base(connection, sqlHelper)
        {
        }

    }
}