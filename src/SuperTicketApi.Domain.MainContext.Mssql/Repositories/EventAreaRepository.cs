﻿namespace SuperTicketApi.Domain.MainContext.Mssql.Repositories
{
    using SuperTicketApi.Domain.MainContext.DTO.IndividualRepositories;
    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.Seedwork;

    /// <summary>
    /// The EventAreaRepository interface.
    /// </summary>
    public class EventAreaRepository : GenericRepository<EventArea>, IEventAreaRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventAreaRepository"/> class.
        /// </summary>
        /// <param name="connection">
        /// The connection.
        /// </param>
        public EventAreaRepository(string connection, ISqlHelper sqlHelper)
            : base(connection, sqlHelper)
        {
        }
    }
}