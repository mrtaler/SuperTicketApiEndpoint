namespace SuperTicketApi.Domain.MainContext.Mssql.Interfaces
{
    using SuperTicketApi.Domain.Seedwork;

    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
        IUnitOfWork CreateTransactional();
    }
}
