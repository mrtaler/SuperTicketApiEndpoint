namespace SuperTicketApi.Domain.MainContext.Mssql.UnitOfWorks
{
    using System;

    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;
    using SuperTicketApi.Domain.Seedwork;

    public class UnitOfWork : IUnitOfWork
    {
        private INetUnitOfWork context;

        public UnitOfWork(INetUnitOfWork context)
        {
            this.context = context;
        }

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

