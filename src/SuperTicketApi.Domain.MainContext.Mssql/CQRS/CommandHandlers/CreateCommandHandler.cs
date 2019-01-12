namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.CommandHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using SuperTicketApi.Domain.MainContext.Command;
    using SuperTicketApi.Domain.MainContext.Command.CreateCommands;
    using SuperTicketApi.Domain.MainContext.Command.Delete;
    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;

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

                var paramList = this.GetDbParametrs(request, newItemId).ToList();

                this.ExecuteSpWithReader(
                     request.Command,
                     this.command,
                     paramList);

                // this.Logger.Info($"Change in db table {typeof(Area).Name} : {returnValue} entities");
                var retId = (int)newItemId.Value;
                var retResp = new DalCommandResponse
                {
                    isSuccess = true,
                    Message = "new entity in Area Table was added",
                    Object = retId
                };
                return await Task.FromResult (retResp);
            }
            catch (Exception ex)
            {
                var ret = new DalCommandResponse { Message = ex.Message };
                return await Task.FromResult (ret);
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

                var paramList = this.GetDbParametrs(request).ToList();

                this.ExecuteSpWithReader(
                     request.Command,
                     this.command,
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
            catch (Exception ex)
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

                var paramList = this.GetDbParametrs(request).ToList();

                this.ExecuteSpWithReader(
                     request.Command,
                     this.command,
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
            catch (Exception ex)
            {
                return new DalCommandResponse { Message = ex.Message };
            }
        }


    }
}
