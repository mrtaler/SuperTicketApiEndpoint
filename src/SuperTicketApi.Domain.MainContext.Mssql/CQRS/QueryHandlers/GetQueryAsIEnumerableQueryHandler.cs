namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.QueryHandlers
{
    using MediatR;
    using Serilog;
    using SuperTicketApi.Domain.MainContext.DTO.Attributes;
    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;
    using SuperTicketApi.Domain.MainContext.Queries.GetListOfDomainEntity;
    using SuperTicketApi.Domain.Seedwork;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The get query as i enumerable handler.
    /// </summary>
    public class GetQueryAsIEnumerableQueryHandler :
        IRequestHandler<GetAreaAsIEnumerableQuery, IEnumerable<Area>>//,
     //   IRequestHandler<GetEventAreaAsIEnumerableQuery, IEnumerable<EventArea>>,
      //  IRequestHandler<GetEventAsIEnumerableQuery, IEnumerable<Event>>,

     //   IRequestHandler<GetEventSeatAsIEnumerableQuery, IEnumerable<EventSeat>>,
     //   IRequestHandler<GetLayoutAsIEnumerableQuery, IEnumerable<Layout>>,
     //   IRequestHandler<GetSeatAsIEnumerableQuery, IEnumerable<Seat>>,
    //    IRequestHandler<GetVenueAsIEnumerableQuery, IEnumerable<Venue>>
    {
        private IUnitOfWorkFactory factory;
        private readonly IDbCommand command;
        public GetQueryAsIEnumerableQueryHandler(IUnitOfWorkFactory factory)
        {
            this.factory = factory;

            Log.Information($"{this.GetType().Name} was started");
        }
       

        #region Implementation of IRequestHandler<in GetAreaAsIEnumerableQuery,IEnumerable<Area>>

        /// <inheritdoc />
        public async Task<IEnumerable<Area>> Handle(GetAreaAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
            var returnList = new List<Area>();

            if (this.command.Connection.State != ConnectionState.Open)
            {
                return null;
            }

            this.command.CommandText = $"select * " +
                                       $"from {typeof(Area).GetAttributeValue((DbTableAttribute dbTable) => dbTable.TableName)}";
            this.command.CommandType = CommandType.Text;

            using (var reader = this.command.ExecuteReader())
            {
                Log.Information($"Run SQL command: {this.command.CommandText}");
                Log.Warning($"{nameof(this.Handle)} connection state: {this.command.Connection.State}");
                while (reader.Read())
                {
                    var art = this.Mapping<Area>(reader);
                    returnList.Add(art);
                }

                Log.Information($"Read from DB: {returnList.Count} entities");
            }

            return await Task.FromResult(returnList);

        }
      
        #endregion
/*
        #region Implementation of IRequestHandler<in GetEventAreaAsIEnumerableQuery,IEnumerable<EventArea>>

        /// <inheritdoc />
        public async Task<IEnumerable<EventArea>> Handle(GetEventAreaAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IRequestHandler<in GetEventAsIEnumerableQuery,IEnumerable<Event>>

        /// <inheritdoc />
        public async Task<IEnumerable<Event>> Handle(GetEventAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IRequestHandler<in GetEventSeatAsIEnumerableQuery,IEnumerable<EventSeat>>

        /// <inheritdoc />
        public async Task<IEnumerable<EventSeat>> Handle(GetEventSeatAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IRequestHandler<in GetLayoutAsIEnumerableQuery,IEnumerable<Layout>>

        /// <inheritdoc />
        public async Task<IEnumerable<Layout>> Handle(GetLayoutAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IRequestHandler<in GetSeatAsIEnumerableQuery,IEnumerable<Seat>>

        /// <inheritdoc />
        public async Task<IEnumerable<Seat>> Handle(GetSeatAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IRequestHandler<in GetVenueAsIEnumerableQuery,IEnumerable<Venue>>

        /// <inheritdoc />
        public async Task<IEnumerable<Venue>> Handle(GetVenueAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion
    */
        /// <summary>
        /// The get item.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="reader">
        /// The reader.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        protected virtual object GetItem(string name, IDataReader reader)
        {
            return reader[name] is DBNull ? null : reader[name];
        }
        
        /// <summary>
        /// The mapping method.
        /// </summary>
        /// <param name="reader">
        /// The data <paramref name="reader"/>.
        /// </param>
        /// <typeparam name="TEntity">Database table class
        /// </typeparam>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        private TEntity Mapping<TEntity>(IDataReader reader) where TEntity : new()
        {
            var ret = new TEntity();
            var columns = typeof(TEntity).GetProperties();

            foreach (var item in columns)
            {
                var currentAttribute = item.GetCustomAttributes(typeof(DbColumnAttribute), true).FirstOrDefault() as DbColumnAttribute;
                string dbColumnName = currentAttribute.columnName;

                var propToSet = ret.GetType().GetProperty(item.Name);
                var valueToSet = Convert.ChangeType(this.GetItem(dbColumnName, reader), propToSet.PropertyType);
                propToSet.SetValue(ret, valueToSet);
            }

            return ret;
        }
    }
}
