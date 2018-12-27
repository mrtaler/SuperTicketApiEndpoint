namespace SuperTicketApi.Domain.MainContext.Mssql.Interfaces
{
    using SuperTicketApi.Domain.MainContext.Mssql.Models;
    using SuperTicketApi.Domain.Seedwork.Repository;

    /// <inheritdoc />
    public interface IEventAddressRepository : IRepository<EventAddress>
    {
    }
}