namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.CommandHandlers
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using SuperTicketApi.Domain.MainContext.Command;
    using SuperTicketApi.Domain.MainContext.Command.CreateCommands;
    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;

    class CreateCommandHandler : BaseCommandHandler, IRequestHandler<CreateAreaCommand, DalCommandResponse>
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

                var newItemId = this.GetSqlParameter(
                    parameterName: "AddedId",  // this returned value
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

                var returnValue = this.ExecuteSpNonQuery(CreateSpCommandPattern.CreateArea, command, parametersList);

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
    }
}
