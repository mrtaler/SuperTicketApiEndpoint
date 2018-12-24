namespace SuperTicketApi.Domain.MainContext.Mssql.Interfaces
{
    using SuperTicketApi.Domain.Seedwork;

    public interface IUnitOfWorkFactory
    {
        IUnitOfWorkMssql Create();
        IUnitOfWorkMssql CreateTransactional();
    }
}
