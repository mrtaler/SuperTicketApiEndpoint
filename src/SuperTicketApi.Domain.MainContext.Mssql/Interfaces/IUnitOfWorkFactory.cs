namespace SuperTicketApi.Domain.MainContext.Mssql.Interfaces
{
    using SuperTicketApi.Domain.Seedwork;

    public interface IUnitOfWorkFactory
    {
        INetUnitOfWork Create();
        INetUnitOfWork CreateTransactional();
    }
}
