namespace SuperTicketApi.Domain.MainContext.Mssql.Interfaces
{
    using SuperTicketApi.Domain.Seedwork;

    public interface IUnitOfWorkMssql : IUnitOfWork
    {
        IEventRepository Events { get; }

        IEventAddressRepository EventAddreses { get; }

        IEventPlaceRepository EventPlaces { get; }
    }
}