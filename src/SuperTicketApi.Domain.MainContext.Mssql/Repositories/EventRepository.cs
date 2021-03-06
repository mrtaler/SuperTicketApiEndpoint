﻿namespace SuperTicketApi.Domain.MainContext.Mssql.Repositories
{
    using SuperTicketApi.Domain.MainContext.DTO.IndividualRepositories;
    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.Seedwork;

    /// <summary>
    /// The EventRepository interface.
    /// </summary>
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventRepository"/> class.
        /// </summary>
        /// <param name="connection">
        /// The connection.
        /// </param>
        public EventRepository(string connection, ISqlHelper sqlHelper)
            : base(connection, sqlHelper)
        {
        }
    }
}