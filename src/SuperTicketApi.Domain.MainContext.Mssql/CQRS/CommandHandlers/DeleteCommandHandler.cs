namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.CommandHandlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using SuperTicketApi.Domain.MainContext.Command;
    using SuperTicketApi.Domain.MainContext.Command.Delete;
    using SuperTicketApi.Domain.MainContext.DTO;
    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.MainContext.Mssql.CQRS.CommandHandlers.General;

    /// <summary>
    /// The delete command handler.
    /// </summary>
    internal class DeleteCommandHandler :
        BaseCommandHandler,
        IRequestHandler<DeleteAreaDomainCommand, CommandResponse>,
        IRequestHandler<DeleteEventAreaDomainCommand, CommandResponse>,
        IRequestHandler<DeleteEventDomainCommand, CommandResponse>,
        IRequestHandler<DeleteEventSeatDomainCommand, CommandResponse>,
        IRequestHandler<DeleteLayoutDomainCommand, CommandResponse>,
        IRequestHandler<DeleteSeatDomainCommand, CommandResponse>,
        IRequestHandler<DeleteVenueDomainCommand, CommandResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCommandHandler"/> class.
        /// </summary>
        /// <param name="unitOfWork">
        /// The unit Of Work.
        /// </param>
        /// <param name="mediatr">
        /// The mediatr.
        /// </param>
        public DeleteCommandHandler(ITabledUnitOfWork unitOfWork, IMediator mediatr)
            : base(unitOfWork, mediatr)
        {
        }

        /// <inheritdoc />
        public async Task<CommandResponse> Handle(DeleteAreaDomainCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.UnitOfWork.AreaRepository.Delete(request.ProjectedAs<Area>());

                var retResp = new CommandResponse
                {
                    IsSuccess = true,
                    Message = "Entity was Deleted",
                    Object = request
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
        public async Task<CommandResponse> Handle(DeleteEventAreaDomainCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.UnitOfWork.EventAreaRepository.Delete(request.ProjectedAs<EventArea>());

                var retResp = new CommandResponse
                {
                    IsSuccess = true,
                    Message = "Entity was Deleted",
                    Object = request
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
        public async Task<CommandResponse> Handle(DeleteEventDomainCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.UnitOfWork.EventRepository.Delete(request.ProjectedAs<Event>());

                var retResp = new CommandResponse
                {
                    IsSuccess = true,
                    Message = "Entity was Deleted",
                    Object = request
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
        public async Task<CommandResponse> Handle(DeleteEventSeatDomainCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.UnitOfWork.EventSeatRepository.Delete(request.ProjectedAs<EventSeat>());

                var retResp = new CommandResponse
                {
                    IsSuccess = true,
                    Message = "Entity was Deleted",
                    Object = request
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
        public async Task<CommandResponse> Handle(DeleteLayoutDomainCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.UnitOfWork.LayoutRepository.Delete(request.ProjectedAs<Layout>());

                var retResp = new CommandResponse
                {
                    IsSuccess = true,
                    Message = "Entity was Deleted",
                    Object = request
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
        public async Task<CommandResponse> Handle(DeleteSeatDomainCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.UnitOfWork.SeatRepository.Delete(request.ProjectedAs<Seat>());

                var retResp = new CommandResponse
                {
                    IsSuccess = true,
                    Message = "Entity was Deleted",
                    Object = request
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
        public async Task<CommandResponse> Handle(DeleteVenueDomainCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.UnitOfWork.VenueRepository.Delete(request.ProjectedAs<Venue>());

                var retResp = new CommandResponse
                {
                    IsSuccess = true,
                    Message = "Entity was Deleted",
                    Object = request
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