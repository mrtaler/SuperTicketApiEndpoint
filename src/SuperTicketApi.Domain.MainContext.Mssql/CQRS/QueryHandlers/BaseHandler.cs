namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.QueryHandlers
{
    using MediatR;
    using Serilog;
    using SuperTicketApi.Domain.MainContext.DTO.Attributes;
    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;
    using SuperTicketApi.Domain.Seedwork;
    using System;
    using System.Data;
    using System.Linq;

    /// <summary>
    /// base query command Handler
    /// </summary>
    public class BaseHandler
    {
        protected readonly INetUnitOfWork uow;
        protected readonly IDbCommand command;
        protected readonly IMediator mediatr;

        public BaseHandler(IUnitOfWorkFactory factory,IMediator mediatr)
        {
            this.uow = factory.Create();
            this.command = uow.CreateCommand();
            this.mediatr = mediatr;
            Log.Information($"{this.GetType().Name} was started");
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
