namespace SuperTicketApi.Domain.MainContext.Mssql.Implimentation
{
    using System.Data;

    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;
    using SuperTicketApi.Domain.MainContext.Mssql.Models;
    using SuperTicketApi.Domain.Seedwork;

    /// <inheritdoc cref="IEventAddressRepository"/>
    public class EventAddressRepository : GenericRepository<EventAddress>, IEventAddressRepository
    {
        public EventAddressRepository(INetUnitOfWork _context)
            : base(_context)
        {
        }

        /// <inheritdoc />
        public override EventAddress GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override void Add(EventAddress item)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override void Update(EventAddress item)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override void Delete(EventAddress item)
        {
            throw new System.NotImplementedException();
        }

        public override EventAddress Mapping(IDataReader reader)
        {
            var ret = new EventAddress();
            ret.Id = (int)this.GetItem("EventAddressId", reader);
            ret.Street = (string)this.GetItem("Street", reader);
            ret.House = (string)this.GetItem("House", reader);
            ret.Description = (string)this.GetItem("Description", reader);
            return ret;
        }
    }
}