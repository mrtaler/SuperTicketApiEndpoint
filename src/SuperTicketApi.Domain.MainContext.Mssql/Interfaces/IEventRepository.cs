using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTicketApi.Domain.MainContext.Mssql.Interfaces
{
    using SuperTicketApi.Domain.MainContext.Mssql.Models;
    using SuperTicketApi.Domain.Seedwork;
    using SuperTicketApi.Domain.Seedwork.Repository;

    public interface IEventRepository : IRepository<Event>
    {
    }
}
