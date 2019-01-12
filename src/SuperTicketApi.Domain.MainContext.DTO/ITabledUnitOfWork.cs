namespace SuperTicketApi.Domain.MainContext.DTO
{
    using SuperTicketApi.Domain.MainContext.DTO.IndividualRepositories;
    using SuperTicketApi.Domain.Seedwork;

    /// <summary>
    /// The Tables interface.
    /// </summary>
    public interface ITabledUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Gets the area.
        /// </summary>
        IAreaRepository AreaRepository { get; }

        /// <summary>
        /// Gets the event.
        /// </summary>
        IEventRepository EventRepository { get; }

        /// <summary>
        /// Gets the event area.
        /// </summary>
        IEventAreaRepository EventAreaRepository { get; }

        /// <summary>
        /// Gets the event seat.
        /// </summary>
        IEventSeatRepository EventSeatRepository { get; }

        /// <summary>
        /// Gets the layout.
        /// </summary>
        ILayoutRepository LayoutRepository { get; }

        /// <summary>
        /// Gets the seat.
        /// </summary>
        ISeatRepository SeatRepository { get; }

        /// <summary>
        /// Gets the venue.
        /// </summary>
        IVenueRepository VenueRepository { get; }
    }
}