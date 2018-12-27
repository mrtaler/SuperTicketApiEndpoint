namespace SuperTicketApi.Domain.MainContext.Mssql.Interfaces
{

    public interface IUnitOfWorkFactory
    {
        IUnitOfWorkMssql Create();
        IUnitOfWorkMssql CreateTransactional();
    }
}
