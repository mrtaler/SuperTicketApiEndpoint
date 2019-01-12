namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.CommandHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using SuperTicketApi.Domain.MainContext.Command;
    using SuperTicketApi.Domain.MainContext.Command.Delete;
    using SuperTicketApi.Domain.MainContext.Mssql.CQRS.CommandHandlers.General;
    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;

    class DeleteCommandHandler :
        BaseCommandHandler,
        IRequestHandler<DeleteAreaCommand, CommandResponse>
    {
        public DeleteCommandHandler(
            IUnitOfWorkFactory factory, IMediator mediatr)
            : base(factory, mediatr)
        {
        }

        public async Task<CommandResponse> Handle(
            DeleteAreaCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                if (this.Command.Connection.State != ConnectionState.Open)
                {
                    return new CommandResponse
                               {
                                   Message = "One or more validation errors occurred.",
                                   DbValidationErrors = new List<string> { "connection was closed" }
                               };
                }

                var paramList = this.GetDbParametrs(request).ToList();

                this.ExecuteSpWithReader(
                    request.Command,
                    this.Command,
                    paramList);

                // this.Logger.Info($"Change in db table {typeof(Area).Name} : {returnValue} entities");
                var retResp = new CommandResponse
                                  {
                                      IsSuccess = true,
                                      Message = "Entity was Updated",
                                      Object = request
                                  };
                return retResp;
            }
            catch (Exception ex)
            {
                return new CommandResponse { Message = ex.Message };
            }
        }


    }
}