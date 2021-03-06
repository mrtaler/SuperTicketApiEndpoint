﻿namespace SuperTicketApi.Domain.MainContext.Mssql.Repositories
{
    using SuperTicketApi.Domain.MainContext.DTO.IndividualRepositories;
    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.Seedwork;

    /// <summary>
    /// The AreaRepository interface.
    /// </summary>
    public class AreaRepository : GenericRepository<Area>, IAreaRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AreaRepository"/> class.
        /// </summary>
        /// <param name="connection">
        /// The connection.
        /// </param>
        public AreaRepository(string connection, ISqlHelper sqlHelper)
            : base(connection, sqlHelper)
        {
        }



    }
}