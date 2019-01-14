﻿namespace SuperTicketApi.Domain.MainContext.Mssql.Repositories
{
    using SuperTicketApi.Domain.MainContext.DTO.IndividualRepositories;
    using SuperTicketApi.Domain.MainContext.DTO.Models;

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
        public LayoutRepository(string connection)
              : base(connection)
        {
        }

    }
}