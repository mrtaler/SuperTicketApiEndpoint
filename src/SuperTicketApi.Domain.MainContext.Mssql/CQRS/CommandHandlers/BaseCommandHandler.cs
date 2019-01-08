namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.CommandHandlers
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using MediatR;

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

         /*   var com = command.ExecuteReader();
            while (com.Read())
            {
                var art = com;
            }*/
            return command.ExecuteNonQuery();
        }
    }
}