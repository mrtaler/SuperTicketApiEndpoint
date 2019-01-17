namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.CommandHandlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using SuperTicketApi.Domain.MainContext.Command;
    using SuperTicketApi.Domain.MainContext.Command.Update;
    using SuperTicketApi.Domain.MainContext.DTO;
    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.MainContext.Mssql.CQRS.CommandHandlers.General;

    /// <summary>
    /// The update command handler.
    /// </summary>
    internal class UpdateCommandHandler :
        BaseCommandHandler,
        IRequestHandler<UpdateAreaDomainCommand, DomainCommandResponse>,
        IRequestHandler<UpdateEventAreaDomainCommand, DomainCommandResponse>,
        IRequestHandler<UpdateEventDomainCommand, DomainCommandResponse>,
        IRequestHandler<UpdateEventSeatDomainCommand, DomainCommandResponse>,
        IRequestHandler<UpdateLayoutDomainCommand, DomainCommandResponse>,
        IRequestHandler<UpdateSeatDomainCommand, DomainCommandResponse>,
        IRequestHandler<UpdateVenueDomainCommand, DomainCommandResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCommandHandler"/> class.
        /// </summary>
        /// <param name="unitOfWork">
        /// The unit Of Work.
        /// </param>
        /// <param name="mediatr">
        /// The mediatr.
        /// </param>
        public UpdateCommandHandler(ITabledUnitOfWork unitOfWork, IMediator mediatr)
            : base(unitOfWork, mediatr)
        {
        }

        /// <inheritdoc />
        public async Task<DomainCommandResponse> Handle(UpdateAreaDomainCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.UnitOfWork.AreaRepository.Update(request.ProjectedAs<Area>());

                // this.Logger.Info($"Change in db table {typeof(Area).Name} : {returnValue} entities");
                var retResp = new DomainCommandResponse
                {
                    IsSuccess = true,
                    Message = "Entity was Updated",
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
        public async Task<DomainCommandResponse> Handle(UpdateEventAreaDomainCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.UnitOfWork.EventAreaRepository.Update(request.ProjectedAs<EventArea>());

                // this.Logger.Info($"Change in db table {typeof(Area).Name} : {returnValue} entities");
                var retResp = new DomainCommandResponse
                {
                    IsSuccess = true,
                    Message = "Entity was Updated",
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
        public async Task<DomainCommandResponse> Handle(UpdateEventDomainCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.UnitOfWork.EventRepository.Update(request.ProjectedAs<Event>());

                // this.Logger.Info($"Change in db table {typeof(Area).Name} : {returnValue} entities");
                var retResp = new DomainCommandResponse
                {
                    IsSuccess = true,
                    Message = "Entity was Updated",
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
        public async Task<DomainCommandResponse> Handle(UpdateEventSeatDomainCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.UnitOfWork.EventSeatRepository.Update(request.ProjectedAs<EventSeat>());

                // this.Logger.Info($"Change in db table {typeof(Area).Name} : {returnValue} entities");
                var retResp = new DomainCommandResponse
                {
                    IsSuccess = true,
                    Message = "Entity was Updated",
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
        public async Task<DomainCommandResponse> Handle(UpdateLayoutDomainCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.UnitOfWork.LayoutRepository.Update(request.ProjectedAs<Layout>());

                // this.Logger.Info($"Change in db table {typeof(Area).Name} : {returnValue} entities");
                var retResp = new DomainCommandResponse
                {
                    IsSuccess = true,
                    Message = "Entity was Updated",
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
        public async Task<DomainCommandResponse> Handle(UpdateSeatDomainCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.UnitOfWork.SeatRepository.Update(request.ProjectedAs<Seat>());

                // this.Logger.Info($"Change in db table {typeof(Area).Name} : {returnValue} entities");
                var retResp = new DomainCommandResponse
                {
                    IsSuccess = true,
                    Message = "Entity was Updated",
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
        public async Task<DomainCommandResponse> Handle(UpdateVenueDomainCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.UnitOfWork.VenueRepository.Update(request.ProjectedAs<Venue>());

                // this.Logger.Info($"Change in db table {typeof(Area).Name} : {returnValue} entities");
                var retResp = new DomainCommandResponse
                {
                    IsSuccess = true,
                    Message = "Entity was Updated",
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