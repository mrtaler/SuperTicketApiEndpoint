namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.CommandHandlers
{
    using MediatR;
    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Globalization;

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
        protected int ExecuteSpNonQuery(
            string sqlSp,
            IDbCommand command,
            IEnumerable<SqlParameter> parameters)
        {
            command.CommandText = sqlSp;
            command.CommandType = CommandType.StoredProcedure;

            //  this.Logger.Info($"Run SQL {nameof(CommandType.StoredProcedure)}: {command.CommandText}");

            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }

            DataBaseErrors dbError;
            var com = command.ExecuteReader(CommandBehavior.CloseConnection);

            while (com.Read())
            {
                dbError = new DataBaseErrors(com);
            }

            return 1; //command.ExecuteNonQuery();
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
    }

    public class DataBaseErrors
    {
        public string ErrorNumber { get; } //= GetItem("ErrorNumber", com);
        public string ErrorSeverity { get; }// = GetItem("ErrorSeverity", com);
        public string ErrorState { get; } //= GetItem("ErrorState", com);
        public string ErrorProcedure { get; }// = GetItem("ErrorProcedure", com);
        public string ErrorLine { get; } //= GetItem("ErrorLine", com);
        public string ErrorMessage { get; } //= GetItem("ErrorMessage", com);

        public DataBaseErrors(IDataReader reader)
        {
            ErrorNumber = reader.GetValueAsString<string>("ErrorNumber");

            ErrorSeverity = reader.GetValueAsString<string>("ErrorSeverity");
            ErrorState = reader.GetValueAsString<string>("ErrorState");
            ErrorProcedure = reader.GetValueAsString<string>("ErrorProcedure");
            ErrorLine = reader.GetValueAsString<string>("ErrorLine");
            ErrorMessage = reader.GetValueAsString<string>("ErrorMessage");
        }

    }

    public static class DbReaderExtension
    {
        public static T GetValueAsString<T>(
            this IDataReader reader,
            string fieldName) where T : class
        {
            return reader[fieldName] is DBNull ? null : (T)Convert.ChangeType(reader[fieldName], typeof(T), CultureInfo.InvariantCulture);
        }
    }
}