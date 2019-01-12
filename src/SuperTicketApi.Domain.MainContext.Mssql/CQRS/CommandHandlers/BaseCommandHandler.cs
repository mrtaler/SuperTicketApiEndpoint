namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.CommandHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Globalization;
    using System.Linq;

    using MediatR;

    using SuperTicketApi.Domain.MainContext.Command;
    using SuperTicketApi.Domain.MainContext.DTO.Attributes;
    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;

    public class BaseCommandHandler : BaseHandler
    {
        /// <inheritdoc />
        public BaseCommandHandler(IUnitOfWorkFactory factory, IMediator mediatr)
            : base(factory, mediatr)
        {
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
        /// <param name="connection">
        /// The <paramref name="connection"/>.
        /// </param>
        /// <param name="parameters">
        /// The <paramref name="parameters"/>.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        protected void ExecuteSpWithReader(
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

            DataBaseErrors dbError = null;
            var com = command.ExecuteReader(CommandBehavior.CloseConnection);

            while (com.Read())
            {
                dbError = new DataBaseErrors(com);
                throw new DatabaseException(dbError);

            }


            // return result; //command.ExecuteNonQuery();
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
        protected List<SqlParameter> GetDbParametrs(
            IRequest<DalCommandResponse> entity,
            SqlParameter returnParametr = null)
        {
            var dataBaseParam = new List<SqlParameter>();
            if (returnParametr != null)
            {
                dataBaseParam.Add(returnParametr);
            }

            var columns = entity.GetType().GetProperties();

            foreach (var item in columns)
            {
                var currentAttribute = item.GetCustomAttributes(typeof(DbColumnAttribute), true).FirstOrDefault() as DbColumnAttribute;
                if (currentAttribute != null)
                {
                    string dbColumnName = currentAttribute.columnName;

                    var value = item.GetValue(entity);

                    var sqlParam = this.GetSqlParameter(dbColumnName, value);

                    dataBaseParam.Add(sqlParam);
                }
            }

            return dataBaseParam;
        }


    }

    public class DataBaseErrors
    {
        public string ErrorNumber { get; } // = GetItem("ErrorNumber", com);
        public string ErrorSeverity { get; }// = GetItem("ErrorSeverity", com);
        public string ErrorState { get; } // = GetItem("ErrorState", com);
        public string ErrorProcedure { get; }// = GetItem("ErrorProcedure", com);
        public string ErrorLine { get; } // = GetItem("ErrorLine", com);
        public string ErrorMessage { get; } // = GetItem("ErrorMessage", com);

        public DataBaseErrors(IDataReader reader)
        {
            this.ErrorNumber = reader.GetValueAsString<string>("ErrorNumber");

            this.ErrorSeverity = reader.GetValueAsString<string>("ErrorSeverity");
            this.ErrorState = reader.GetValueAsString<string>("ErrorState");
            this.ErrorProcedure = reader.GetValueAsString<string>("ErrorProcedure");
            this.ErrorLine = reader.GetValueAsString<string>("ErrorLine");
            this.ErrorMessage = reader.GetValueAsString<string>("ErrorMessage");
        }

    }
    public static class DbReaderExtension
    {
        public static T GetValueAsString<T>(
            this IDataReader reader,
            string fieldName) where T : class
        {
            return reader[fieldName] is DBNull
                ? null
                : (T)Convert.ChangeType(reader[fieldName], typeof(T), CultureInfo.InvariantCulture);
        }
    }
}