namespace SuperTicketApi.Domain.MainContext.Mssql
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Reflection;

    using SuperTicketApi.Domain.MainContext.DTO.Attributes;
    using SuperTicketApi.Domain.MainContext.Mssql.CQRS.CommandHandlers.General;
    using SuperTicketApi.Domain.Seedwork;
    using SuperTicketApi.Domain.Seedwork.Repository;

    /// <summary>
    /// Generic Repository
    /// </summary>
    /// <typeparam name="TEntity">Table in db</typeparam>
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : DomainEntity, new()
    {
        /// <summary>
        /// The sql helper.
        /// </summary>
        private ISqlHelper sqlHelper;

        /// <summary>
        /// The cmd.
        /// </summary>
        private string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{TEntity}"/> class. 
        /// </summary>
        /// <param name="connectionString">
        /// The connection String.
        /// </param>
        /// <param name="sqlHelper">
        /// The sql Helper.
        /// </param>
        protected GenericRepository(string connectionString, ISqlHelper sqlHelper)
        {
            this.sqlHelper = sqlHelper;
            this.connectionString = connectionString;
        }


        /// <inheritdoc />
        public void Add(IEnumerable<TEntity> items)
        {
            foreach (var item in items)
            {
                this.Add(item);
            }
        }

        /// <inheritdoc />
        public void Delete(IEnumerable<TEntity> items)
        {
            foreach (var item in items)
            {
                this.Delete(item);
            }
        }

        /// <inheritdoc />
        public void Update(IEnumerable<TEntity> items)
        {
            foreach (var item in items)
            {
                this.Update(item);
            }
        }

        /// <inheritdoc />
        public IEnumerable<TEntity> GetAll()
        {
            var returnList = new List<TEntity>();
            using (var con = sqlHelper.CreateConnection(this.connectionString))
            {
                var COMMAND = $"select * " +
                                        $"from {typeof(TEntity).GetAttributeValue((DbTableAttribute dbTable) => dbTable.TableName)}";
                using (var rdr = sqlHelper.ExecuteReader(con, COMMAND))
                {
                    while (rdr.Read())
                    {
                        var art = this.Mapping(rdr);
                        returnList.Add(art);
                    }
                }
            }

            return returnList;
        }

        /// <inheritdoc />
        public TEntity GetById(int id)
        {
            using (var con = sqlHelper.CreateConnection(this.connectionString))
            {
                var returnEntity = new TEntity();
                var COMMAND = $"select * " +
                                        $"from {typeof(TEntity).GetAttributeValue((DbTableAttribute dbTable) => dbTable.TableName)} " +
                                        $"where {this.GetIdTableColumnName()} = {id}";
                using (var rdr = sqlHelper.ExecuteReader(con, COMMAND))
                {
                    while (rdr.Read())
                    {
                        returnEntity = this.Mapping(rdr);
                    }
                }
                return returnEntity;
            }
        }

        /// <inheritdoc />
        public int Add(TEntity item)
        {
            using (var con = sqlHelper.CreateConnection(this.connectionString))
            {
                var newItemId = this.GetSqlParameter(
                    parameterName: "AddedId", // this returned value
                    parameterDirection: ParameterDirection.Output,
                    sqlDbType: SqlDbType.Int,
                    size: 1);
                var paramList = this.GetSqlParameters(item, newItemId).ToList();
                using (var rdr = sqlHelper.ExecuteReader(con, item.Command, CommandType.StoredProcedure, paramList.ToArray()))
                {
                    var retId = (int)newItemId.Value;
                    return retId;
                }
            }
        }

        /// <inheritdoc />
        public void Update(TEntity item)
        {
            using (var con = sqlHelper.CreateConnection(this.connectionString))
            {
                var paramList = this.GetSqlParameters(item, null, true).ToList();




                using (var rdr = sqlHelper.ExecuteReader(
                    con,
                    item.Command,
                    CommandType.StoredProcedure,
                    paramList.ToArray()))
                {
                    return;
                }
            }
        }

        /// <inheritdoc />
        public void Delete(TEntity item)
        {
            using (var con = sqlHelper.CreateConnection(this.connectionString))
            {
                var dataBaseParam = new List<SqlParameter>();


                var idColumnName = this.GetIdTableColumnName();
                var property = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(p => p.GetCustomAttributes(typeof(IdColumnAttribute), false).Count() == 1);
                var value = property.GetValue(item);
                var sqlParam = this.GetSqlParameter(idColumnName, value);
                dataBaseParam.Add(sqlParam);


                using (var rdr = sqlHelper.ExecuteReader(
                    con,
                    item.Command,
                    CommandType.StoredProcedure,
                    dataBaseParam.ToArray()))
                {
                    return;
                }
            }
        }

        /// <summary>
        /// The get sql <c>param</c>.
        /// </summary>
        /// <param name="parameterName">
        /// The parameter name.
        /// </param>
        /// <param name="parameterValue">
        /// The parameter value.
        /// </param>
        /// <returns>
        /// The <see cref="SqlParameter"/>.
        /// </returns>
        protected SqlParameter GetSqlParameter(
            string parameterName,
            object parameterValue)
        {
            return new SqlParameter
            {
                ParameterName = $"@{parameterName}",
                Value = parameterValue
            };
        }

        /// <summary>
        /// The get sql parameter.
        /// </summary>
        /// <param name="parameterName">The parameter name.</param>
        /// <param name="parameterDirection">The parameter direction.</param>
        /// <param name="sqlDbType">Parameter type</param>
        /// <param name="size">parameter <paramref name="size"/>(for string)</param>
        /// <returns>
        /// The <see cref="System.Data.SqlClient.SqlParameter" /> .
        /// </returns>
        protected SqlParameter GetSqlParameter(
            string parameterName,
            ParameterDirection parameterDirection,
            SqlDbType sqlDbType,
            int size = 1)
        {
            return new SqlParameter
            {
                ParameterName = $"@{parameterName}",
                Direction = parameterDirection,
                Size = size,
                SqlDbType = sqlDbType
            };
        }

        /// <summary>
        /// The execute sp non query.
        /// </summary>
        /// <param name="sqlSp">
        /// The sql store procedure.
        /// </param>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <param name="parameters">
        /// The <paramref name="parameters"/>.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>Affected Records 
        /// </returns>
        protected int ExecuteSpWithReader(
            string sqlSp,
            IDbCommand command,
            IEnumerable<SqlParameter> parameters)
        {
            command.CommandText = sqlSp;
            command.CommandType = CommandType.StoredProcedure;

            // this.Logger.Info($"Run SQL {nameof(CommandType.StoredProcedure)}: {command.CommandText}");
            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }

            var com = command.ExecuteReader(CommandBehavior.CloseConnection);

            while (com.Read())
            {
                throw new DatabaseException(new DataBaseErrors(com));
            }

            return com.RecordsAffected;
        }

        /// <summary>
        /// The mapping method.
        /// </summary>
        /// <param name="entity">
        /// The <paramref name="entity"/>.
        /// </param>
        /// <param name="returnParameter">
        /// The return parameter.
        /// </param>
        /// <returns>
        /// The <see cref="List"></see>
        ///     Sql Parameter
        /// </returns>
        protected List<SqlParameter> GetSqlParameters(
            TEntity entity,
            SqlParameter returnParameter = null,
            bool isUseIdColumn = false)
        {
            var dataBaseParam = new List<SqlParameter>();
            if (returnParameter != null)
            {
                dataBaseParam.Add(returnParameter);
            }

            var idColumnName = this.GetIdTableColumnName();
            var columns = entity.GetType().GetProperties();

            foreach (var item in columns)
            {


                var currentAttribute = item.GetCustomAttributes(typeof(DbColumnAttribute), true).FirstOrDefault() as DbColumnAttribute;



                if (currentAttribute != null)
                {
                    if (currentAttribute.ColumnName == idColumnName)
                    {
                        if (!isUseIdColumn)
                        {
                            continue;
                        }
                    }

                    string dataBaseColumnName = currentAttribute.ColumnName;

                    var value = item.GetValue(entity);

                    var sqlParam = this.GetSqlParameter(dataBaseColumnName, value);

                    dataBaseParam.Add(sqlParam);
                }
            }

            return dataBaseParam;
        }

        /// <summary>
        /// The get id table column name.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        protected string GetIdTableColumnName()
        {
            var properties = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(p => p.GetCustomAttributes(typeof(IdColumnAttribute), false).Count() == 1);

            var dataBaseAttribute = (properties.GetCustomAttributes(typeof(DbColumnAttribute), true).FirstOrDefault() as DbColumnAttribute).ColumnName;

            /*var dnAttribute = item.GetCustomAttributes(
                        typeof(IdColumnAttribute), true
                    ).FirstOrDefault() as IdColumnAttribute;*/
            return dataBaseAttribute;
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
        public TEntity Mapping(IDataReader reader)
        {
            var ret = new TEntity();
            var columns = typeof(TEntity).GetProperties();

            foreach (var item in columns)
            {
                var currentAttribute = item.GetCustomAttributes(
                                           typeof(DbColumnAttribute), true).FirstOrDefault()
                                           as DbColumnAttribute;
                if (currentAttribute != null)
                {
                    string dbColumnName = currentAttribute.ColumnName;

                    var propToSet = ret.GetType().GetProperty(item.Name);
                    var valueToSet = Convert.ChangeType(
                        this.GetItem(dbColumnName, reader),
                        propToSet.PropertyType);
                    propToSet.SetValue(ret, valueToSet);
                }
            }

            return ret;
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
        private object GetItem(string name, IDataReader reader)
        {
            return reader[name] is DBNull ? null : reader[name];
        }

        #region Implementation of IDisposable

        /// <inheritdoc />
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
