﻿namespace SuperTicketApi.Domain.MainContext.Mssql.Repositories
{
    using SuperTicketApi.Domain.MainContext.DTO.IndividualRepositories;
    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.Seedwork;

    /// <summary>
    /// The VenueRepository interface.
    /// </summary>
    public class VenueRepository : GenericRepository<Venue>, IVenueRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VenueRepository"/> class.
        /// </summary>
        /// <param name="connection">
        /// The connection.
        /// </param>
        public VenueRepository(string connection, ISqlHelper sqlHelper)
            : base(connection, sqlHelper)
        {
        }
    }
}