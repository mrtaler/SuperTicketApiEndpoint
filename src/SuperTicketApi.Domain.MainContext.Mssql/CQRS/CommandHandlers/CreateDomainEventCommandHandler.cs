namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.CommandHandlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using SuperTicketApi.Domain.MainContext.Command;
    using SuperTicketApi.Domain.MainContext.Command.CreateCommands;
    using SuperTicketApi.Domain.MainContext.DTO;
    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.MainContext.Mssql.CQRS.CommandHandlers.General;

    internal class CreateDomainEventCommandHandler
        : BaseCommandHandler,
          IRequestHandler<CreateEventDomainCommand, DomainCommandResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCommandHandler"/> class.
        /// </summary>
        /// <param name="unitOfWork">
        /// The unit Of Work.
        /// </param>
        /// <param name="mediatr">
        /// The mediatr.
        /// </param>
        public CreateDomainEventCommandHandler(ITabledUnitOfWork unitOfWork, IMediator mediatr)
            : base(unitOfWork, mediatr)
        {
        }

        /// <inheritdoc />
        public async Task<DomainCommandResponse> Handle(CreateEventDomainCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var retId = this.UnitOfWork.EventRepository.Add(request.ProjectedAs<Event>());
                var returnedObject = request.ProjectedAs<Event>();
                returnedObject.Id = retId;
                var retResp = new DomainCommandResponse
                {
                    IsSuccess = true,
                    Message = "new entity in Event Table was added",
                    Object = returnedObject
                };
                return await Task.FromResult(retResp);
            }
            catch (Exception ex)
            {
                var ret = new DomainCommandResponse { Message = ex.Message };
                return await Task.FromResult(ret);
            }
        }
    }

}
