using MediatR;
using SuperTicketApi.Domain.MainContext.Command;
using SuperTicketApi.Domain.MainContext.Command.CreateCommands;
using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.CommandHandlers
{
    class CreateCommandHandler : BaseHandler,IRequestHandler<CreateAreaCommand, DalCommandResponse>
    {
        public CreateCommandHandler(IUnitOfWorkFactory factory, IMediator mediatr) : base(factory, mediatr)
        {
        }

        public async Task<DalCommandResponse> Handle(CreateAreaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (this.command.Connection.State != ConnectionState.Open)
                {
                    return new DalCommandResponse
                    {
                        Message = "One or more validation errors occurred.",
                        DbValidationErrors = new List<string> { "connection was closed" }
                    };
                }

                string sqlSp = "[dbo].[CreateArea]";


                var newItemId = this.GetSqlParameter(
                    parameterName: "AddedId",
                    parameterDirection: ParameterDirection.Output,
                    sqlDbType: SqlDbType.Int,
                    size: 1);
                var parametersList = new List<SqlParameter>
            {
                newItemId,
                this.GetSqlParameter("LayoutId", request.LayoutId),
                this.GetSqlParameter("Description", request.Description),
                this.GetSqlParameter("CoordX", request.CoordX),
                this.GetSqlParameter("CoordY", request.CoordY)
            };

                var returnValue = this.ExecuteSpNonQuery(sqlSp, command, parametersList);

                // this.Logger.Info($"Change in db table {typeof(Area).Name} : {returnValue} entities");

                var retId = (int)newItemId.Value;
                var retResp = new DalCommandResponse
                {
                    isSuccess = true,
                    Message = "new entity in Area Table was added",
                    Object = retId
                };
                return retResp;
            }
            catch (System.Exception ex)
            {
                return new DalCommandResponse { Message = ex.Message };
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

            return command.ExecuteNonQuery();
        }
    }
}
