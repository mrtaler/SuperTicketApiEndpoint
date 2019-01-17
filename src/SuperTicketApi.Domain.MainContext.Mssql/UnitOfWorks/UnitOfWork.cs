namespace SuperTicketApi.Domain.MainContext.Mssql.UnitOfWorks
{
    using Microsoft.Extensions.Options;
    using SuperTicketApi.ApiSettings.JsonSettings.ConnectionStrings;
    using SuperTicketApi.Domain.MainContext.DTO;
    using SuperTicketApi.Domain.MainContext.DTO.IndividualRepositories;
    using SuperTicketApi.Domain.MainContext.Mssql.Repositories;
    using SuperTicketApi.Domain.Seedwork;
    using System;

    /// <summary>
    /// The ado net unit of work.
    /// </summary>
    public class UnitOfWork : ITabledUnitOfWork
    {
        /// <summary>
        /// The connection string.
        /// </summary>
        private readonly string connectionString;

        private readonly ISqlHelper sqlHelper;

        /// <summary>
        /// Gets the area.
        /// </summary>
        private IAreaRepository areaRepository;

        /// <summary>
        /// Gets the event.
        /// </summary>
        private IEventRepository eventRepository;

        /// <summary>
        /// Gets the event area.
        /// </summary>
        private IEventAreaRepository eventAreaRepository;

        /// <summary>
        /// Gets the event seat.
        /// </summary>
        private IEventSeatRepository eventSeatRepository;

        /// <summary>
        /// Gets the layout.
        /// </summary>
        private ILayoutRepository layoutRepository;

        /// <summary>
        /// Gets the seat.
        /// </summary>
        private ISeatRepository seatRepository;

        /// <summary>
        /// Gets the venue.
        /// </summary>
        private IVenueRepository venueRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdoNetUnitOfWork"/> class.
        /// </summary>
        /// <param name="connectionString">
        /// The connection string.
        /// </param>
        public UnitOfWork(IOptions<ConnectionStrings> connectionString, ISqlHelper sqlHelper)
        {
            this.sqlHelper = sqlHelper;
            this.connectionString = connectionString.Value.ConnectionString;
        }


        /// <inheritdoc />
        /// <summary>
        /// The area repository
        /// </summary>
        public IAreaRepository AreaRepository =>
            this.areaRepository
            ?? (this.areaRepository = new AreaRepository(this.connectionString, sqlHelper));

        /// <inheritdoc />
        /// <summary>
        /// The event.
        /// </summary>
        public IEventRepository EventRepository =>
            this.eventRepository
            ?? (this.eventRepository = new EventRepository(this.connectionString, sqlHelper));

        /// <summary>
        /// The event area.
        /// </summary>
        public IEventAreaRepository EventAreaRepository =>
            this.eventAreaRepository
            ?? (this.eventAreaRepository = new EventAreaRepository(this.connectionString, sqlHelper));

        /// <summary>
        /// The event seat.
        /// </summary>
        public IEventSeatRepository EventSeatRepository =>
            this.eventSeatRepository
            ?? (this.eventSeatRepository = new EventSeatRepository(this.connectionString, sqlHelper));

        /// <summary>
        /// The layout.
        /// </summary>
        public ILayoutRepository LayoutRepository =>
            this.layoutRepository
            ?? (this.layoutRepository = new LayoutRepository(this.connectionString, sqlHelper));

        /// <summary>
        /// The <see cref="seatRepository"/> repository
        /// </summary>
        public ISeatRepository SeatRepository =>
            this.seatRepository
            ?? (this.seatRepository = new SeatRepository(this.connectionString, sqlHelper));

        /// <summary>
        /// The venue.
        /// </summary>
        public IVenueRepository VenueRepository =>
            this.venueRepository
            ?? (this.venueRepository = new VenueRepository(this.connectionString, sqlHelper));

        /// <inheritdoc />
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc />
        public void Commit()
        {
            throw new NotImplementedException();
        }
    }
}