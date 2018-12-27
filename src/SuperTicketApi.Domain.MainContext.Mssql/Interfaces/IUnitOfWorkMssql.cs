namespace SuperTicketApi.Domain.MainContext.Mssql.Interfaces
{
    using SuperTicketApi.Domain.Seedwork;
    
    /// <inheritdoc />
    public interface IUnitOfWorkMssql : IUnitOfWork
    {
        IEventRepository Events { get; }

        IEventAddressRepository EventAddreses { get; }

        IEventPlaceRepository EventPlaces { get; }
    }
}