namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.QueryHandlers
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Serilog;

    using SuperTicketApi.Domain.MainContext.DTO;
    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.MainContext.Queries.GetListOfDomainEntity;

    /// <summary>
    /// The get query as i enumerable handler.
    /// </summary>
    public class GetQueryAsIEnumerableQueryHandler : BaseQueryHandler,
        IRequestHandler<GetAreaAsIEnumerableQuery, IEnumerable<Area>>,
        IRequestHandler<GetEventAreaAsIEnumerableQuery, IEnumerable<EventArea>>,
        IRequestHandler<GetEventAsIEnumerableQuery, IEnumerable<Event>>,
        IRequestHandler<GetEventSeatAsIEnumerableQuery, IEnumerable<EventSeat>>,
        IRequestHandler<GetLayoutAsIEnumerableQuery, IEnumerable<Layout>>,
        IRequestHandler<GetSeatAsIEnumerableQuery, IEnumerable<Seat>>,
        IRequestHandler<GetVenueAsIEnumerableQuery, IEnumerable<Venue>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetQueryAsIEnumerableQueryHandler"/> class.
        /// </summary>
        /// <param name="unitOfWork">
        /// The unit Of Work.
        /// </param>
        /// <param name="mediatr">
        /// The <paramref name="mediatr"/>.
        /// </param>
        public GetQueryAsIEnumerableQueryHandler(
           ITabledUnitOfWork unitOfWork,
            IMediator mediatr) : base(unitOfWork, mediatr)
        {
            Log.Information($"{this.GetType().Name} was started");
        }

        #region Implementation of IRequestHandler<in GetAreaAsIEnumerableQuery,IEnumerable<Area>>

        /// <inheritdoc />
        public async Task<IEnumerable<Area>> Handle(GetAreaAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
            var returnList = this.UnitOfWork.AreaRepository.GetAll();
            return await Task.FromResult(returnList);
        }

        #endregion

        #region Implementation of IRequestHandler<in GetEventAreaAsIEnumerableQuery,IEnumerable<EventArea>>

        /// <inheritdoc />
        public async Task<IEnumerable<EventArea>> Handle(GetEventAreaAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
           var returnList = this.UnitOfWork.EventAreaRepository.GetAll();
            return await Task.FromResult(returnList);
        }

        #endregion

        #region Implementation of IRequestHandler<in GetEventAsIEnumerableQuery,IEnumerable<Event>>

        /// <inheritdoc />
        public async Task<IEnumerable<Event>> Handle(GetEventAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
          var returnList = this.UnitOfWork.EventRepository.GetAll();
            return await Task.FromResult(returnList);
        }

        #endregion

        #region Implementation of IRequestHandler<in GetEventSeatAsIEnumerableQuery,IEnumerable<EventSeat>>

        /// <inheritdoc />
        public async Task<IEnumerable<EventSeat>> Handle(GetEventSeatAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
            var returnList = this.UnitOfWork.EventSeatRepository.GetAll();
            return await Task.FromResult(returnList);
        }

        #endregion

        #region Implementation of IRequestHandler<in GetLayoutAsIEnumerableQuery,IEnumerable<Layout>>

        /// <inheritdoc />
        public async Task<IEnumerable<Layout>> Handle(GetLayoutAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
            var returnList = this.UnitOfWork.LayoutRepository.GetAll();
            return await Task.FromResult(returnList);
        }

        #endregion

        #region Implementation of IRequestHandler<in GetSeatAsIEnumerableQuery,IEnumerable<Seat>>

        /// <inheritdoc />
        public async Task<IEnumerable<Seat>> Handle(GetSeatAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
           var returnList = this.UnitOfWork.SeatRepository.GetAll();
            return await Task.FromResult(returnList);
        }

        #endregion

        #region Implementation of IRequestHandler<in GetVenueAsIEnumerableQuery,IEnumerable<Venue>>

        /// <inheritdoc />
        public async Task<IEnumerable<Venue>> Handle(GetVenueAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
          var returnList = this.UnitOfWork.VenueRepository.GetAll();
            return await Task.FromResult(returnList);
        }

        #endregion
    }
}
