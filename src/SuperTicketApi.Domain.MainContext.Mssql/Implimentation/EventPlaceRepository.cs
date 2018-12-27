namespace SuperTicketApi.Domain.MainContext.Mssql.Implimentation
{
    using System.Data;

    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;
    using SuperTicketApi.Domain.MainContext.Mssql.Models;
    using SuperTicketApi.Domain.Seedwork;

    /// <inheritdoc cref="IEventPlaceRepository"/>
    public class EventPlaceRepository : GenericRepository<EventPlace>, IEventPlaceRepository
    {
        public EventPlaceRepository(INetUnitOfWork _context)
            : base(_context)
        {
        }

        /// <inheritdoc />
        public override EventPlace GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override void Add(EventPlace item)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override void Update(EventPlace item)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override void Delete(EventPlace item)
        {
            throw new System.NotImplementedException();
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