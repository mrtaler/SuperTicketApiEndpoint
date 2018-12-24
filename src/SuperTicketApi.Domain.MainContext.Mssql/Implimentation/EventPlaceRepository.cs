namespace SuperTicketApi.Domain.MainContext.Mssql.Interfaces
{
    using System.Data;

    using SuperTicketApi.Domain.MainContext.Mssql.Models;
    using SuperTicketApi.Domain.Seedwork;

    public class EventPlaceRepository : GenericRepository<EventPlace>, IEventPlaceRepository
    {
        public EventPlaceRepository(INetUnitOfWork _context)
            : base(_context)
        {
        }

        public override EventPlace Mapping(IDataReader reader)
        {
            var ret = new EventPlace();
            ret.Id = (int)this.GetItem("EventPlaceId", reader);
            ret.PlacesAdmin = (string)this.GetItem("PlacesAdmin", reader);
            ret.AdminTelephone = (string)this.GetItem("AdminTelephone", reader);
            ret.CostPerHour = (decimal)this.GetItem("CostPerHour", reader);
            return ret;
        }
    }
}