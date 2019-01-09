namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.CommandHandlers
{
    using MediatR;
    using SuperTicketApi.Domain.MainContext.Command;
    using SuperTicketApi.Domain.MainContext.Command.CreateCommands;
    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    class CreateCommandHandler 
        : BaseCommandHandler, IRequestHandler<CreateAreaCommand, DalCommandResponse>
    {
        public CreateCommandHandler(
            IUnitOfWorkFactory factory, IMediator mediatr)
            : base(factory, mediatr)
        {
        }

        public async Task<DalCommandResponse> Handle(
            CreateAreaCommand request,
            CancellationToken cancellationToken)
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

                var paramList = GetDbParametrs(request, newItemId).ToList();

                this.ExecuteSpWithReader(
                     request.Command,
                     command,
                     paramList);

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

    class UpdateCommandHandler :
        BaseCommandHandler,
        IRequestHandler<UpdateAreaCommand, DalCommandResponse>
    {
        public UpdateCommandHandler(
            IUnitOfWorkFactory factory, IMediator mediatr)
            : base(factory, mediatr)
        {
        }

        public async Task<DalCommandResponse> Handle(
            UpdateAreaCommand request,
            CancellationToken cancellationToken)
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

                var paramList = GetDbParametrs(request).ToList();

                this.ExecuteSpWithReader(
                     request.Command,
                     command,
                     paramList);

                // this.Logger.Info($"Change in db table {typeof(Area).Name} : {returnValue} entities");

                var retResp = new DalCommandResponse
                {
                    isSuccess = true,
                    Message = "Entity was Updated",
                    Object = request
                };
                return retResp;
            }
            catch (System.Exception ex)
            {
                return new DalCommandResponse { Message = ex.Message };
            }
        }


    }
    class DeleteCommandHandler :
        BaseCommandHandler,
        IRequestHandler<DeleteAreaCommand, DalCommandResponse>
    {
        public DeleteCommandHandler(
            IUnitOfWorkFactory factory, IMediator mediatr)
            : base(factory, mediatr)
        {
        }

        public async Task<DalCommandResponse> Handle(
            DeleteAreaCommand request,
            CancellationToken cancellationToken)
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

                var paramList = GetDbParametrs(request).ToList();

                this.ExecuteSpWithReader(
                     request.Command,
                     command,
                     paramList);

                // this.Logger.Info($"Change in db table {typeof(Area).Name} : {returnValue} entities");

                var retResp = new DalCommandResponse
                {
                    isSuccess = true,
                    Message = "Entity was Updated",
                    Object = request
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
