namespace SuperTicketApi.Domain.Seedwork
{
    using System;
    using System.Data;

    public interface INetUnitOfWork : IDisposable
    {
        IDbCommand CreateCommand();
        void SaveChange();
    }
}