namespace SuperTicketApi.Domain.MainContext.Mssql
{
    using System;

    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;
    using SuperTicketApi.Domain.Seedwork;

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
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        public void Commit()
        {
            this.context.SaveChange();
        }
    }
}

