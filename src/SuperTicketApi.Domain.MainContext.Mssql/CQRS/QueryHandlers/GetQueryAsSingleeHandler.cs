namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.QueryHandlers
{
    using MediatR;
    using Serilog;
    using SuperTicketApi.Domain.MainContext.DTO;
    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.MainContext.Queries.GetSingleDomainEntity;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The get query as i enumerable handler.
    /// </summary>
    public class GetQueryAsSingleHandler : BaseQueryHandler,
        IRequestHandler<GetSingleAreaQuery, Area>,
        IRequestHandler<GetSingleEventAreaQuery, EventArea>,
        IRequestHandler<GetSingleEventQuery, Event>,
        IRequestHandler<GetSingleEventSeatQuery, EventSeat>,
        IRequestHandler<GetSingleLayoutQuery, Layout>,
        IRequestHandler<GetSingleSeatQuery, Seat>,
        IRequestHandler<GetSingleVenueQuery, Venue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetQueryAsSingleHandler"/> class.
        /// </summary>
        /// <param name="factory">
        /// The factory.
        /// </param>
        /// <param name="mediatr">
        /// The mediatr.
        /// </param>
        public GetQueryAsSingleHandler(ITabledUnitOfWork unitOfWork, IMediator mediatr) : base(unitOfWork, mediatr)
        {
            Log.Information($"{this.GetType().Name} was started");
        }

        #region Implementation of IRequestHandler<in GetSingleAreaQuery,Area>

        /// <inheritdoc />
        public async Task<Area> Handle(GetSingleAreaQuery request, CancellationToken cancellationToken)
        {
            var retVal = this.UnitOfWork.AreaRepository.GetById(request.Id);
            return await Task.FromResult(retVal);
        }

        #endregion

        #region Implementation of IRequestHandler<in GetSingleEventAreaQuery,EventArea>

        /// <inheritdoc />
        public async Task<EventArea> Handle(GetSingleEventAreaQuery request, CancellationToken cancellationToken)
        {
            var retVal = this.UnitOfWork.EventAreaRepository.GetById(request.Id);
            return await Task.FromResult(retVal);
        }

        #endregion

        #region Implementation of IRequestHandler<in GetSingleEventQuery,Event>

        /// <inheritdoc />
        public async Task<Event> Handle(GetSingleEventQuery request, CancellationToken cancellationToken)
        {
            var retVal = this.UnitOfWork.EventRepository.GetById(request.Id);
            return await Task.FromResult(retVal);
        }

        #endregion

        #region Implementation of IRequestHandler<in GetSingleEventSeatQuery,EventSeat>

        /// <inheritdoc />
        public async Task<EventSeat> Handle(GetSingleEventSeatQuery request, CancellationToken cancellationToken)
        {
            var retVal = this.UnitOfWork.EventSeatRepository.GetById(request.Id);
            return await Task.FromResult(retVal);
        }

        #endregion

        #region Implementation of IRequestHandler<in GetSingleLayoutQuery,Layout>

        /// <inheritdoc />
        public async Task<Layout> Handle(GetSingleLayoutQuery request, CancellationToken cancellationToken)
        {
            var retVal = this.UnitOfWork.LayoutRepository.GetById(request.Id);
            return await Task.FromResult(retVal);
        }

        #endregion

        #region Implementation of IRequestHandler<in GetSingleSeatQuery,Seat>

        /// <inheritdoc />
        public async Task<Seat> Handle(GetSingleSeatQuery request, CancellationToken cancellationToken)
        {
            var retVal = this.UnitOfWork.SeatRepository.GetById(request.Id);
            return await Task.FromResult(retVal);
        }

        #endregion

        #region Implementation of IRequestHandler<in GetSingleVenueQuery,Venue>

        /// <inheritdoc />
        public async Task<Venue> Handle(GetSingleVenueQuery request, CancellationToken cancellationToken)
        {
            var retVal = this.UnitOfWork.VenueRepository.GetById(request.Id);
            return await Task.FromResult(retVal);
        }

        #endregion
    }
}
