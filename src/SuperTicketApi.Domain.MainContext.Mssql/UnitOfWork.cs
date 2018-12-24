namespace SuperTicketApi.Domain.MainContext.Mssql
{
    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;
    using SuperTicketApi.Domain.Seedwork;
    using System;

    public class UnitOfWork : IUnitOfWorkMssql
    {
        private INetUnitOfWork context;


        private IEventRepository events;
        private IEventAddressRepository eventAddreses;
        private IEventPlaceRepository eventPlaces;

        public UnitOfWork(INetUnitOfWork context)
        {
            this.context = context;
        }

        public IEventRepository Events =>
            this.events ??
            (this.events = 
                 new EventRepository(this.context));

        public IEventAddressRepository EventAddreses =>
            this.eventAddreses ??
            (this.eventAddreses = 
                 new EventAddressRepository(this.context));

        public IEventPlaceRepository EventPlaces =>
            this.eventPlaces ??
            (this.eventPlaces = 
                 new EventPlaceRepository(this.context));

        #region Dispose
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        public void Commit()
        {
            this.context.SaveChange();
        }
    }
}

