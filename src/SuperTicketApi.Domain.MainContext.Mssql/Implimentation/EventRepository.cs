using System;

namespace SuperTicketApi.Domain.MainContext.Mssql.Interfaces
{
    using System.Data;

    using SuperTicketApi.Domain.MainContext.Mssql.Models;
    using SuperTicketApi.Domain.Seedwork;

    public class EventRepository : GenericRepository<Events>, IEventRepository
    {
        public EventRepository(INetUnitOfWork _context)
            : base(_context)
        {
        }

        public override Events Mapping(IDataReader reader)
        {
            var ret = new Events();
            ret.Id = (int)this.GetItem("EventId", reader);
            ret.Name = (string)this.GetItem("Name", reader);
            ret.Banner = (string)this.GetItem("Banner", reader);
            ret.Description = (string)this.GetItem("Description", reader);
            ret.StartAt = (DateTimeOffset)this.GetItem("StartAt", reader);
            ret.Runtime = (TimeSpan)this.GetItem("Runtime", reader);
            ret.Fk_EventPlaceId = (int)this.GetItem("Fk_EventPlaceId", reader);
            ret.MaxSeats = (int)this.GetItem("MaxSeats", reader);
            return ret;
        }
    }
}
