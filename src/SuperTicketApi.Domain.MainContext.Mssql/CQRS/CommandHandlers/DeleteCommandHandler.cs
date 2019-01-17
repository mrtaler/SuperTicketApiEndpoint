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
        IRequestHandler<DeleteAreaDomainCommand, DomainCommandResponse>,
        IRequestHandler<DeleteEventAreaDomainCommand, DomainCommandResponse>,
        IRequestHandler<DeleteEventDomainCommand, DomainCommandResponse>,
        IRequestHandler<DeleteEventSeatDomainCommand, DomainCommandResponse>,
        IRequestHandler<DeleteLayoutDomainCommand, DomainCommandResponse>,
        IRequestHandler<DeleteSeatDomainCommand, DomainCommandResponse>,
        IRequestHandler<DeleteVenueDomainCommand, DomainCommandResponse>
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
        public async Task<DomainCommandResponse> Handle(DeleteAreaDomainCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.UnitOfWork.AreaRepository.Delete(request.ProjectedAs<Area>());

                var retResp = new DomainCommandResponse
                {
                    IsSuccess = true,
                    Message = "Entity was Deleted",
                    Object = request
                };

                return await Task.FromResult(retResp);
            }
            catch (Exception ex)
            {
                var ret = new DomainCommandResponse { Message = ex.Message };
                return await Task.FromResult(ret);
            }
        }

        /// <inheritdoc />
        public async Task<DomainCommandResponse> Handle(DeleteEventAreaDomainCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.UnitOfWork.EventAreaRepository.Delete(request.ProjectedAs<EventArea>());

                var retResp = new DomainCommandResponse
                {
                    IsSuccess = true,
                    Message = "Entity was Deleted",
                    Object = request
                };

                return await Task.FromResult(retResp);
            }
            catch (Exception ex)
            {
                var ret = new DomainCommandResponse { Message = ex.Message };
                return await Task.FromResult(ret);
            }
        }

        /// <inheritdoc />
        public async Task<DomainCommandResponse> Handle(DeleteEventDomainCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.UnitOfWork.EventRepository.Delete(request.ProjectedAs<Event>());

                var retResp = new DomainCommandResponse
                {
                    IsSuccess = true,
                    Message = "Entity was Deleted",
                    Object = request
                };

                return await Task.FromResult(retResp);
            }
            catch (Exception ex)
            {
                var ret = new DomainCommandResponse { Message = ex.Message };
                return await Task.FromResult(ret);
            }
        }

        /// <inheritdoc />
        public async Task<DomainCommandResponse> Handle(DeleteEventSeatDomainCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.UnitOfWork.EventSeatRepository.Delete(request.ProjectedAs<EventSeat>());

                var retResp = new DomainCommandResponse
                {
                    IsSuccess = true,
                    Message = "Entity was Deleted",
                    Object = request
                };

                return await Task.FromResult(retResp);
            }
            catch (Exception ex)
            {
                var ret = new DomainCommandResponse { Message = ex.Message };
                return await Task.FromResult(ret);
            }
        }

        /// <inheritdoc />
        public async Task<DomainCommandResponse> Handle(DeleteLayoutDomainCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.UnitOfWork.LayoutRepository.Delete(request.ProjectedAs<Layout>());

                var retResp = new DomainCommandResponse
                {
                    IsSuccess = true,
                    Message = "Entity was Deleted",
                    Object = request
                };

                return await Task.FromResult(retResp);
            }
            catch (Exception ex)
            {
                var ret = new DomainCommandResponse { Message = ex.Message };
                return await Task.FromResult(ret);
            }
        }

        /// <inheritdoc />
        public async Task<DomainCommandResponse> Handle(DeleteSeatDomainCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.UnitOfWork.SeatRepository.Delete(request.ProjectedAs<Seat>());

                var retResp = new DomainCommandResponse
                {
                    IsSuccess = true,
                    Message = "Entity was Deleted",
                    Object = request
                };

                return await Task.FromResult(retResp);
            }
            catch (Exception ex)
            {
                var ret = new DomainCommandResponse { Message = ex.Message };
                return await Task.FromResult(ret);
            }
        }

        /// <inheritdoc />
        public async Task<DomainCommandResponse> Handle(DeleteVenueDomainCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.UnitOfWork.VenueRepository.Delete(request.ProjectedAs<Venue>());

                var retResp = new DomainCommandResponse
                {
                    IsSuccess = true,
                    Message = "Entity was Deleted",
                    Object = request
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