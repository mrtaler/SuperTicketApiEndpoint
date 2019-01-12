namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.CommandHandlers.General
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    using MediatR;

    using SuperTicketApi.Domain.MainContext.Command;
    using SuperTicketApi.Domain.MainContext.DTO.Attributes;
    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;

    /// <summary>
    /// The base command handler.
    /// </summary>
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
            IRequest<CommandResponse> entity,
            SqlParameter returnParameter = null)
        {
            var dataBaseParam = new List<SqlParameter>();
            if (returnParameter != null)
            {
                dataBaseParam.Add(returnParameter);
            }

            var columns = entity.GetType().GetProperties();

            foreach (var item in columns)
            {
                var currentAttribute = item.GetCustomAttributes(typeof(DbColumnAttribute), true).FirstOrDefault() as DbColumnAttribute;
                if (currentAttribute != null)
                {
                    string dataBaseColumnName = currentAttribute.ColumnName;

                    var value = item.GetValue(entity);

                    var sqlParam = this.GetSqlParameter(dataBaseColumnName, value);

                    dataBaseParam.Add(sqlParam);
                }
            }

            return dataBaseParam;
        }
    }
}