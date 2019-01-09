namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.QueryHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    using MediatR;

    using Serilog;

    using SuperTicketApi.Domain.MainContext.DTO.Attributes;
    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;

    public class BaseQueryHandler : BaseHandler
    {
        /// <inheritdoc />
        public BaseQueryHandler(IUnitOfWorkFactory factory, IMediator mediatr)
            : base(factory, mediatr)
        {
        }

        protected IEnumerable<T> GetAllFromDb<T>() where T : new()
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
                Log.Warning($"Handler for {typeof(T).Name} connection state: {this.command.Connection.State}");
                while (reader.Read())
                {
                    var art = this.Mapping<T>(reader);
                    returnList.Add(art);
                }

                Log.Information($"Read from DB: {returnList.Count} entities");
            }

            return returnList;
        }

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
        protected TEntity Mapping<TEntity>(IDataReader reader) where TEntity : new()
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