using System;

namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.QueryHandlers
{
    using MediatR;
    using Serilog;
    using SuperTicketApi.Domain.MainContext.DTO.Attributes;
    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;
    using SuperTicketApi.Domain.MainContext.Queries.GetSingleDomainEntity;
    using SuperTicketApi.Domain.Seedwork;
    using System.Data;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The get query as i enumerable handler.
    /// </summary>
    public class GetQueryAsSingleeHandler : BaseHandler,
        IRequestHandler<GetSingleAreaQuery, Area>,
        IRequestHandler<GetSingleEventAreaQuery, EventArea>,
        IRequestHandler<GetSingleEventQuery, Event>,
        IRequestHandler<GetSingleEventSeatQuery, EventSeat>,
        IRequestHandler<GetSingleLayoutQuery, Layout>,
        IRequestHandler<GetSingleSeatQuery, Seat>,
        IRequestHandler<GetSingleVenueQuery, Venue>
    {
        public GetQueryAsSingleeHandler(IUnitOfWorkFactory factory, IMediator mediatr) : base(factory, mediatr)
        {
            Log.Information($"{this.GetType().Name} was started");
        }

        private string GetIdTableColumnName<T>() where T : DomainEntity
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(p => p.GetCustomAttributes(typeof(IdColumnAttribute), false).Count() ==1);

            var dnAttribute = (properties.GetCustomAttributes(
                             typeof(DbColumnAttribute), true
                         ).FirstOrDefault() as DbColumnAttribute).columnName;

            /*var dnAttribute = item.GetCustomAttributes(
                        typeof(IdColumnAttribute), true
                    ).FirstOrDefault() as IdColumnAttribute;*/

            return dnAttribute;
;
        }

        private T GetSingleByIdFromDb<T>(int id) where T : DomainEntity, new()
        {
            var returnEntity = new T();
            if (this.command.Connection.State != ConnectionState.Open)
            {
                return default(T);
            }

            var columnName = GetIdTableColumnName<T>();

            this.command.CommandText = $"select * " +
                $"from {typeof(T).GetAttributeValue((DbTableAttribute dbTable) => dbTable.TableName)} " +
                $"where {GetIdTableColumnName<T>()} = {id}";
             this.command.CommandType = CommandType.Text;

              using (var reader = this.command.ExecuteReader())
              {
                  Log.Information($"Run SQL command: {this.command.CommandText}");
                  Log.Warning($"{nameof(this.Handle)} connection state: {this.command.Connection.State}");
                  if (reader.Read())
                  {
                     returnEntity = this.Mapping<T>(reader);
                     
                  }

                  Log.Information($"Read table " +
                      $"{typeof(T).GetAttributeValue((DbTableAttribute dbTable) => dbTable.TableName)}" +
                      $" by id from DB");
              }
            return returnEntity;

        }

        #region Implementation of IRequestHandler<in GetSingleAreaQuery,Area>

        /// <inheritdoc />
        public async Task<Area> Handle(GetSingleAreaQuery request, CancellationToken cancellationToken)
        {
            var retVal = GetSingleByIdFromDb<Area>(request.Id);
            return await Task.FromResult(retVal);
        }

        #endregion

        #region Implementation of IRequestHandler<in GetSingleEventAreaQuery,EventArea>

        /// <inheritdoc />
        public async Task<EventArea> Handle(GetSingleEventAreaQuery request, CancellationToken cancellationToken)
        {
            var retVal = GetSingleByIdFromDb<EventArea>(request.Id);
            return await Task.FromResult(retVal);
        }

        #endregion

        #region Implementation of IRequestHandler<in GetSingleEventQuery,Event>

        /// <inheritdoc />
        public async Task<Event> Handle(GetSingleEventQuery request, CancellationToken cancellationToken)
        {
            var retVal = GetSingleByIdFromDb<Event>(request.Id);
            return await Task.FromResult(retVal);
        }

        #endregion

        #region Implementation of IRequestHandler<in GetSingleEventSeatQuery,EventSeat>

        /// <inheritdoc />
        public async Task<EventSeat> Handle(GetSingleEventSeatQuery request, CancellationToken cancellationToken)
        {
            var retVal = GetSingleByIdFromDb<EventSeat>(request.Id);
            return await Task.FromResult(retVal);
        }

        #endregion

        #region Implementation of IRequestHandler<in GetSingleLayoutQuery,Layout>

        /// <inheritdoc />
        public async Task<Layout> Handle(GetSingleLayoutQuery request, CancellationToken cancellationToken)
        {
            var retVal = GetSingleByIdFromDb<Layout>(request.Id);
            return await Task.FromResult(retVal);
        }

        #endregion

        #region Implementation of IRequestHandler<in GetSingleSeatQuery,Seat>

        /// <inheritdoc />
        public async Task<Seat> Handle(GetSingleSeatQuery request, CancellationToken cancellationToken)
        {
            var retVal = GetSingleByIdFromDb<Seat>(request.Id);
            return await Task.FromResult(retVal);
        }

        #endregion

        #region Implementation of IRequestHandler<in GetSingleVenueQuery,Venue>

        /// <inheritdoc />
        public async Task<Venue> Handle(GetSingleVenueQuery request, CancellationToken cancellationToken)
        {
            var retVal = GetSingleByIdFromDb<Venue>(request.Id);
            return await Task.FromResult(retVal);
        }

        #endregion
    }
}
