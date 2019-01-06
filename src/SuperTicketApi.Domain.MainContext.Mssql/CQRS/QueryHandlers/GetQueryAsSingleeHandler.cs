//using System;

//namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.QueryHandlers
//{
//    using System.Threading;
//    using System.Threading.Tasks;

//    using MediatR;

//    using SuperTicketApi.Domain.MainContext.DTO.Models;
//    using SuperTicketApi.Domain.MainContext.Queries.GetSingleDomainEntity;

//    /// <summary>
//    /// The get query as i enumerable handler.
//    /// </summary>
//    public class GetQueryAsSingleeHandler : 
//        IRequestHandler<GetSingleAreaQuery, Area>,
//        IRequestHandler<GetSingleEventAreaQuery, EventArea>,
//        IRequestHandler<GetSingleEventQuery,Event>,

//        IRequestHandler<GetSingleEventSeatQuery, EventSeat>,
//        IRequestHandler<GetSingleLayoutQuery, Layout>,
//        IRequestHandler<GetSingleSeatQuery, Seat>,
//        IRequestHandler<GetSingleVenueQuery, Venue>
//    {
//        #region Implementation of IRequestHandler<in GetSingleAreaQuery,Area>

//        /// <inheritdoc />
//        public async Task<Area> Handle(GetSingleAreaQuery request, CancellationToken cancellationToken)
//        {
//            throw new NotImplementedException();
//        }

//        #endregion

//        #region Implementation of IRequestHandler<in GetSingleEventAreaQuery,EventArea>

//        /// <inheritdoc />
//        public async Task<EventArea> Handle(GetSingleEventAreaQuery request, CancellationToken cancellationToken)
//        {
//            throw new NotImplementedException();
//        }

//        #endregion

//        #region Implementation of IRequestHandler<in GetSingleEventQuery,Event>

//        /// <inheritdoc />
//        public async Task<Event> Handle(GetSingleEventQuery request, CancellationToken cancellationToken)
//        {
//            throw new NotImplementedException();
//        }

//        #endregion

//        #region Implementation of IRequestHandler<in GetSingleEventSeatQuery,EventSeat>

//        /// <inheritdoc />
//        public async Task<EventSeat> Handle(GetSingleEventSeatQuery request, CancellationToken cancellationToken)
//        {
//            throw new NotImplementedException();
//        }

//        #endregion

//        #region Implementation of IRequestHandler<in GetSingleLayoutQuery,Layout>

//        /// <inheritdoc />
//        public async Task<Layout> Handle(GetSingleLayoutQuery request, CancellationToken cancellationToken)
//        {
//            throw new NotImplementedException();
//        }

//        #endregion

//        #region Implementation of IRequestHandler<in GetSingleSeatQuery,Seat>

//        /// <inheritdoc />
//        public async Task<Seat> Handle(GetSingleSeatQuery request, CancellationToken cancellationToken)
//        {
//            throw new NotImplementedException();
//        }

//        #endregion

//        #region Implementation of IRequestHandler<in GetSingleVenueQuery,Venue>

//        /// <inheritdoc />
//        public async Task<Venue> Handle(GetSingleVenueQuery request, CancellationToken cancellationToken)
//        {
//            throw new NotImplementedException();
//        }

//        #endregion
//    }
//}
