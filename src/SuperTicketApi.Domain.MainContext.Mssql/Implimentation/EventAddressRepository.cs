namespace SuperTicketApi.Domain.MainContext.Mssql.Interfaces
{
    using System.Data;

    using SuperTicketApi.Domain.MainContext.Mssql.Models;
    using SuperTicketApi.Domain.Seedwork;

    public class EventAddressRepository : GenericRepository<EventAddress>, IEventAddressRepository
    {
        public EventAddressRepository(INetUnitOfWork _context)
            : base(_context)
        {
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