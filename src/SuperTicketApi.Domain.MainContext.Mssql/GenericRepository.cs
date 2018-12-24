namespace SuperTicketApi.Domain.MainContext.Mssql
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using Serilog;

    using SuperTicketApi.Domain.Seedwork;
    using SuperTicketApi.Domain.Seedwork.Repository;
    using SuperTicketApi.Domain.Seedwork.Specifications.Interfaces;

    public abstract class GenericRepository<T> : IRepository<T>
        where T : class
    {

        IDbCommand cmd;
        INetUnitOfWork context;

        protected GenericRepository(INetUnitOfWork _context)
        {
            this.context = _context;
            this.cmd = this.context.CreateCommand();
            Log.Information($"{this.GetType().Name} was started");
        }



        #region Get
        public T Get(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
           /* using (SqlConnection con = new SqlConnection(cmd.Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand($"select * from SuperTicketApiMssql.dbo.{typeof(T).Name}", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                }
            }*/
            var returnList = new List<T>();
            if (this.cmd.Connection.State==ConnectionState.Open)
            {


                this.cmd.CommandText = $"select * " +
                                       $"from {typeof(T).Name}";
                this.cmd.CommandType = CommandType.Text;

                using (var reader = this.cmd.ExecuteReader())
                {
                    Log.Information($"Run SQL command: {this.cmd.CommandText}");
                    Log.Warning($"{nameof(this.GetAll)} connection state: {this.cmd.Connection.State}");
                    while (reader.Read())
                    {
                        var art = this.Mapping(reader);
                        returnList.Add(art);
                    }

                    Log.Information($"Read from DB: {returnList.Count} entities");
                }

                return returnList;
            }

            return null;
        }

        public IEnumerable<T> AllMatching(
            ISpecification<T> filter = null,
            IOrderSpecification<T> orderBy = null,
            IIncludeSpecification<T> includes = null)
        {
            throw new NotImplementedException();
        }

        public T OneMatching(ISpecification<T> filter = null, IOrderSpecification<T> orderBy = null, IIncludeSpecification<T> includes = null)
        {
            throw new NotImplementedException();
        }


        #endregion


        #region Update Delete Insert

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Add(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void Remove(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public void Modify(T item)
        {
            throw new NotImplementedException();
        }

        public void Modify(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        #endregion

        abstract public T Mapping(IDataReader reader);

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

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}