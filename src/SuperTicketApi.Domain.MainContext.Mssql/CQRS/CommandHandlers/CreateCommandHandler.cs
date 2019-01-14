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

    /// <summary>
    /// The create command handler.
    /// </summary>
    internal class CreateCommandHandler
        : BaseCommandHandler,
          IRequestHandler<CreateAreaDomainCommand, CommandResponse>,
          IRequestHandler<CreateEventAreaDomainCommand, CommandResponse>,
          IRequestHandler<CreateEventDomainCommand, CommandResponse>,
          IRequestHandler<CreateEventSeatDomainCommand, CommandResponse>,
          IRequestHandler<CreateLayoutDomainCommand, CommandResponse>,
          IRequestHandler<CreateSeatDomainCommand, CommandResponse>,
          IRequestHandler<CreateVenueDomainCommand, CommandResponse>
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
        public CreateCommandHandler(ITabledUnitOfWork unitOfWork, IMediator mediatr)
            : base(unitOfWork, mediatr)
        {
        }

        /// <inheritdoc />
        public async Task<CommandResponse> Handle(CreateAreaDomainCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var retId = this.UnitOfWork.AreaRepository.Add(request.ProjectedAs<Area>());
                var returnedObject = request.ProjectedAs<Area>();
                returnedObject.Id = retId;
                var retResp = new CommandResponse
                {
                    IsSuccess = true,
                    Message = "new entity in Area Table was added",
                    Object = returnedObject
                };
                return await Task.FromResult(retResp);
            }
            catch (Exception ex)
            {
                var ret = new CommandResponse { Message = ex.Message };
                return await Task.FromResult(ret);
            }
        }

        /// <inheritdoc />
        public async Task<CommandResponse> Handle(CreateEventAreaDomainCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var retId = this.UnitOfWork.EventAreaRepository.Add(request.ProjectedAs<EventArea>());
                var returnedObject = request.ProjectedAs<EventArea>();
                returnedObject.Id = retId;
                var retResp = new CommandResponse
                {
                    IsSuccess = true,
                    Message = "new entity in EventArea Table was added",
                    Object = returnedObject
                };
                return await Task.FromResult(retResp);
            }
            catch (Exception ex)
            {
                var ret = new CommandResponse { Message = ex.Message };
                return await Task.FromResult(ret);
            }
        }

        /// <inheritdoc />
        public async Task<CommandResponse> Handle(CreateEventDomainCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var retId = this.UnitOfWork.EventRepository.Add(request.ProjectedAs<Event>());
                var returnedObject = request.ProjectedAs<Event>();
                returnedObject.Id = retId;
                var retResp = new CommandResponse
                {
                    IsSuccess = true,
                    Message = "new entity in Event Table was added",
                    Object = returnedObject
                };
                return await Task.FromResult(retResp);
            }
            catch (Exception ex)
            {
                var ret = new CommandResponse { Message = ex.Message };
                return await Task.FromResult(ret);
            }
        }

        /// <inheritdoc />
        public async Task<CommandResponse> Handle(CreateEventSeatDomainCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var retId = this.UnitOfWork.EventSeatRepository.Add(request.ProjectedAs<EventSeat>());
                var returnedObject = request.ProjectedAs<EventSeat>();
                returnedObject.Id = retId;
                var retResp = new CommandResponse
                {
                    IsSuccess = true,
                    Message = "new entity in EventSeat Table was added",
                    Object = returnedObject
                };
                return await Task.FromResult(retResp);
            }
            catch (Exception ex)
            {
                var ret = new CommandResponse { Message = ex.Message };
                return await Task.FromResult(ret);
            }
        }

        /// <inheritdoc />
        public async Task<CommandResponse> Handle(CreateLayoutDomainCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var retId = this.UnitOfWork.LayoutRepository.Add(request.ProjectedAs<Layout>());
                var returnedObject = request.ProjectedAs<Layout>();
                returnedObject.Id = retId;
                var retResp = new CommandResponse
                {
                    IsSuccess = true,
                    Message = "new entity in Layout Table was added",
                    Object = returnedObject
                };
                return await Task.FromResult(retResp);
            }
            catch (Exception ex)
            {
                var ret = new CommandResponse { Message = ex.Message };
                return await Task.FromResult(ret);
            }
        }

        /// <inheritdoc />
        public async Task<CommandResponse> Handle(CreateSeatDomainCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var retId = this.UnitOfWork.SeatRepository.Add(request.ProjectedAs<Seat>());
                var returnedObject = request.ProjectedAs<Seat>();
                returnedObject.Id = retId;
                var retResp = new CommandResponse
                {
                    IsSuccess = true,
                    Message = "new entity in Seat Table was added",
                    Object = returnedObject
                };
                return await Task.FromResult(retResp);
            }
            catch (Exception ex)
            {
                var ret = new CommandResponse { Message = ex.Message };
                return await Task.FromResult(ret);
            }
        }

        /// <inheritdoc />
        public async Task<CommandResponse> Handle(CreateVenueDomainCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var retId = this.UnitOfWork.VenueRepository.Add(request.ProjectedAs<Venue>());
                var returnedObject = request.ProjectedAs<Venue>();
                returnedObject.Id = retId;
                var retResp = new CommandResponse
                {
                    IsSuccess = true,
                    Message = "new entity in Venue Table was added",
                    Object = returnedObject
                };
                return await Task.FromResult(retResp);
            }
            catch (Exception ex)
            {
                var ret = new CommandResponse { Message = ex.Message };
                return await Task.FromResult(ret);
            }
        }
    }
}
