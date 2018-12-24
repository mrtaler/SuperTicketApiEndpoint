namespace SuperTicketApi.Domain.MainContext.Mssql.Interfaces
{
    using SuperTicketApi.Domain.MainContext.Mssql.Models;
    using SuperTicketApi.Domain.Seedwork;
    using SuperTicketApi.Domain.Seedwork.Repository;

    public interface IUnitOfWorkMssql : IUnitOfWork
    {
        IEventRepository Events { get; }

        IEventAddressRepository EventAddreses { get; }

        IEventPlaceRepository EventPlaces { get; }
    }
}