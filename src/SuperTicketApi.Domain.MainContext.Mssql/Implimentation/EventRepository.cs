namespace SuperTicketApi.Domain.MainContext.Mssql.Implimentation
{
    using System;
    using System.Data;

    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;
    using SuperTicketApi.Domain.MainContext.Mssql.Models;
    using SuperTicketApi.Domain.Seedwork;

    /// <inheritdoc cref="IEventRepository"/>
    public class EventRepository : GenericRepository<Events>, IEventRepository
    {
        public EventRepository(INetUnitOfWork _context)
            : base(_context)
        {
        }

        /// <inheritdoc />
        public override Events GetById(int id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override void Add(Events item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override void Update(Events item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override void Delete(Events item)
        {
            throw new NotImplementedException();
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
