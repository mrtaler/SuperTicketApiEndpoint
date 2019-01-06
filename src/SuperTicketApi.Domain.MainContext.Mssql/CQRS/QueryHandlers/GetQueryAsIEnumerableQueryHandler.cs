namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.QueryHandlers
{
    using MediatR;
    using Serilog;
    using SuperTicketApi.Domain.MainContext.DTO.Attributes;
    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;
    using SuperTicketApi.Domain.MainContext.Queries.GetListOfDomainEntity;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The get query as i enumerable handler.
    /// </summary>
    public class GetQueryAsIEnumerableQueryHandler : BaseHandler,
        IRequestHandler<GetAreaAsIEnumerableQuery, IEnumerable<Area>>,
        IRequestHandler<GetEventAreaAsIEnumerableQuery, IEnumerable<EventArea>>,
        IRequestHandler<GetEventAsIEnumerableQuery, IEnumerable<Event>>,
        IRequestHandler<GetEventSeatAsIEnumerableQuery, IEnumerable<EventSeat>>,
        IRequestHandler<GetLayoutAsIEnumerableQuery, IEnumerable<Layout>>,
        IRequestHandler<GetSeatAsIEnumerableQuery, IEnumerable<Seat>>,
        IRequestHandler<GetVenueAsIEnumerableQuery, IEnumerable<Venue>>
    {
        public GetQueryAsIEnumerableQueryHandler(IUnitOfWorkFactory factory) : base(factory)
        {
            Log.Information($"{this.GetType().Name} was started");
        }

        private IEnumerable<T> GetAllFromDb<T>() where T : new()
        {
            var returnList = new List<T>();
            if (this.command.Connection.State != ConnectionState.Open)
            {
                return null;
            }

            this.command.CommandText = $"select * " +
                                      $"from {typeof(T).GetAttributeValue((DbTableAttribute dbTable) => dbTable.TableName)}";
            this.command.CommandType = CommandType.Text;

            using (var reader = this.command.ExecuteReader())
            {
                Log.Information($"Run SQL command: {this.command.CommandText}");
                Log.Warning($"{nameof(this.Handle)} connection state: {this.command.Connection.State}");
                while (reader.Read())
                {
                    var art = this.Mapping<T>(reader);
                    returnList.Add(art);
                }

                Log.Information($"Read from DB: {returnList.Count} entities");
            }

            return returnList;

        }

        #region Implementation of IRequestHandler<in GetAreaAsIEnumerableQuery,IEnumerable<Area>>

        /// <inheritdoc />
        public async Task<IEnumerable<Area>> Handle(GetAreaAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
            var returnList = GetAllFromDb<Area>();
            return await Task.FromResult(returnList);

        }

        #endregion

        #region Implementation of IRequestHandler<in GetEventAreaAsIEnumerableQuery,IEnumerable<EventArea>>

        /// <inheritdoc />
        public async Task<IEnumerable<EventArea>> Handle(GetEventAreaAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
            var returnList = GetAllFromDb<EventArea>();
            return await Task.FromResult(returnList);
        }

        #endregion

        #region Implementation of IRequestHandler<in GetEventAsIEnumerableQuery,IEnumerable<Event>>

        /// <inheritdoc />
        public async Task<IEnumerable<Event>> Handle(GetEventAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
            var returnList = GetAllFromDb<Event>();
            return await Task.FromResult(returnList);
        }

        #endregion

        #region Implementation of IRequestHandler<in GetEventSeatAsIEnumerableQuery,IEnumerable<EventSeat>>

        /// <inheritdoc />
        public async Task<IEnumerable<EventSeat>> Handle(GetEventSeatAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
            var returnList = GetAllFromDb<EventSeat>();
            return await Task.FromResult(returnList);
        }

        #endregion

        #region Implementation of IRequestHandler<in GetLayoutAsIEnumerableQuery,IEnumerable<Layout>>

        /// <inheritdoc />
        public async Task<IEnumerable<Layout>> Handle(GetLayoutAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
            var returnList = GetAllFromDb<Layout>();
            return await Task.FromResult(returnList);
        }

        #endregion

        #region Implementation of IRequestHandler<in GetSeatAsIEnumerableQuery,IEnumerable<Seat>>

        /// <inheritdoc />
        public async Task<IEnumerable<Seat>> Handle(GetSeatAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
            var returnList = GetAllFromDb<Seat>();
            return await Task.FromResult(returnList);
        }

        #endregion

        #region Implementation of IRequestHandler<in GetVenueAsIEnumerableQuery,IEnumerable<Venue>>

        /// <inheritdoc />
        public async Task<IEnumerable<Venue>> Handle(GetVenueAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
            var returnList = GetAllFromDb<Venue>();
            return await Task.FromResult(returnList);
        }

        #endregion

    }
}
