namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.QueryHandlers
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Serilog;

    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;
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
        /// <param name="factory">
        /// The factory.
        /// </param>
        /// <param name="mediatr">
        /// The <paramref name="mediatr"/>.
        /// </param>
        public GetQueryAsIEnumerableQueryHandler(
            IUnitOfWorkFactory factory,
            IMediator mediatr) : base(factory, mediatr)
        {
            Log.Information($"{this.GetType().Name} was started");
        }

        #region Implementation of IRequestHandler<in GetAreaAsIEnumerableQuery,IEnumerable<Area>>

        /// <inheritdoc />
        public async Task<IEnumerable<Area>> Handle(GetAreaAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
            var returnList = this.GetAllFromDb<Area>();
            return await Task.FromResult(returnList);
        }

        #endregion

        #region Implementation of IRequestHandler<in GetEventAreaAsIEnumerableQuery,IEnumerable<EventArea>>

        /// <inheritdoc />
        public async Task<IEnumerable<EventArea>> Handle(GetEventAreaAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
            var returnList = this.GetAllFromDb<EventArea>();
            return await Task.FromResult(returnList);
        }

        #endregion

        #region Implementation of IRequestHandler<in GetEventAsIEnumerableQuery,IEnumerable<Event>>

        /// <inheritdoc />
        public async Task<IEnumerable<Event>> Handle(GetEventAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
            var returnList = this.GetAllFromDb<Event>();
            return await Task.FromResult(returnList);
        }

        #endregion

        #region Implementation of IRequestHandler<in GetEventSeatAsIEnumerableQuery,IEnumerable<EventSeat>>

        /// <inheritdoc />
        public async Task<IEnumerable<EventSeat>> Handle(GetEventSeatAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
            var returnList = this.GetAllFromDb<EventSeat>();
            return await Task.FromResult(returnList);
        }

        #endregion

        #region Implementation of IRequestHandler<in GetLayoutAsIEnumerableQuery,IEnumerable<Layout>>

        /// <inheritdoc />
        public async Task<IEnumerable<Layout>> Handle(GetLayoutAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
            var returnList = this.GetAllFromDb<Layout>();
            return await Task.FromResult(returnList);
        }

        #endregion

        #region Implementation of IRequestHandler<in GetSeatAsIEnumerableQuery,IEnumerable<Seat>>

        /// <inheritdoc />
        public async Task<IEnumerable<Seat>> Handle(GetSeatAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
            var returnList = this.GetAllFromDb<Seat>();
            return await Task.FromResult(returnList);
        }

        #endregion

        #region Implementation of IRequestHandler<in GetVenueAsIEnumerableQuery,IEnumerable<Venue>>

        /// <inheritdoc />
        public async Task<IEnumerable<Venue>> Handle(GetVenueAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
            var returnList = this.GetAllFromDb<Venue>();
            return await Task.FromResult(returnList);
        }

        #endregion

    }
}
