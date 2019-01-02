namespace SuperTicketApi.Domain.MainContext.Mssql
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Linq.Expressions;
    using Serilog;

    using SuperTicketApi.Domain.MainContext.Mssql.Attributes;
    using SuperTicketApi.Domain.Seedwork;
    using SuperTicketApi.Domain.Seedwork.Repository;
    using SuperTicketApi.Domain.Seedwork.Specifications.Interfaces;

    /// <summary>
    /// Generic Repository
    /// </summary>
    /// <typeparam name="T">Table in db</typeparam>
    public abstract class GenericRepository<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// The cmd.
        /// </summary>
        private readonly IDbCommand command;

        /// <summary>
        /// The context.
        /// </summary>
        private readonly INetUnitOfWork context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{T}"/> class.
        /// </summary>
        /// <param name="context">
        /// The _context.
        /// </param>
        protected GenericRepository(INetUnitOfWork context)
        {
            this.context = context;
            this.command = this.context.CreateCommand();
            Log.Information($"{this.GetType().Name} was started");

            var ss = GetTableColumnNames();

        }

        #region Get

        /// <inheritdoc />
        public IEnumerable<T> GetAll(IColumnSpecification<T> columns)
        {
            var returnList = new List<T>();
            if (this.command.Connection.State == ConnectionState.Open)
            {
                this.command.CommandText = $"select * " +
                                       $"from {typeof(T).GetAttributeValue((DbTable dbTable) => dbTable.TableName)}";
                this.command.CommandType = CommandType.Text;

                using (var reader = this.command.ExecuteReader())
                {
                    Log.Information($"Run SQL command: {this.command.CommandText}");
                    Log.Warning($"{nameof(this.GetAll)} connection state: {this.command.Connection.State}");
                    while (reader.Read())
                    {
                        var art = this.Mapping(reader, columns);
                        returnList.Add(art);
                    }

                    Log.Information($"Read from DB: {returnList.Count} entities");
                }

                return returnList;
            }

            return null;
        }

        #endregion

        /// <inheritdoc />
        public void Add(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                this.Add(item);
            }
        }

        /// <inheritdoc />
        public void Delete(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                this.Delete(item);
            }
        }

        /// <inheritdoc />
        public void Update(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                this.Update(item);
            }
        }

        #region abstract

        /// <inheritdoc />
        public abstract T GetById(int id, IColumnSpecification<T> columns);

        /// <inheritdoc />
        public abstract void Add(T item);

        /// <inheritdoc />
        public abstract void Update(T item);

        /// <inheritdoc />
        public abstract void Delete(T item);

        /// <summary>
        /// The mapping.
        /// </summary>
        /// <param name="reader">
        /// The reader.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public abstract T Mapping(IDataReader reader, IColumnSpecification<T> columns);

        #endregion

        /// <inheritdoc />
        public void Dispose()
        {
            this.context.Dispose();
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

        protected IEnumerable<string> GetTableColumnNames()
        {
            var columns = new List<string>();
            var classProperties = typeof(T).GetProperties();
            foreach (var item in classProperties)
            {
                var dnAttribute = item.GetCustomAttributes(
                              typeof(DbColumn), true
                          ).FirstOrDefault() as DbColumn;

                if (dnAttribute != null)
                {
                    columns.Add(dnAttribute.columnName);
                }
            }


            return columns;
        }

        protected string GetPropertyName(Expression<Func<T, string>> expression)
        {
            var memberExpersion = (ConstantExpression)expression.Body;

            return memberExpersion.Value.ToString();
        }
      
    }
}