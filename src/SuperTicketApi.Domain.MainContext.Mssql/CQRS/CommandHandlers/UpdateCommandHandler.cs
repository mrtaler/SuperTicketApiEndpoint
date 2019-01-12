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
        IRequestHandler<UpdateAreaCommand, CommandResponse>,
        IRequestHandler<UpdateEventAreaCommand, CommandResponse>,
        IRequestHandler<UpdateEventCommand, CommandResponse>,
        IRequestHandler<UpdateEventSeatCommand, CommandResponse>,
        IRequestHandler<UpdateLayoutCommand, CommandResponse>,
        IRequestHandler<UpdateSeatCommand, CommandResponse>,
        IRequestHandler<UpdateVenueCommand, CommandResponse>
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
        public async Task<CommandResponse> Handle(UpdateAreaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.UnitOfWork.AreaRepository.Update(request.ProjectedAs<Area>());

                // this.Logger.Info($"Change in db table {typeof(Area).Name} : {returnValue} entities");
                var retResp = new CommandResponse
                {
                    IsSuccess = true,
                    Message = "Entity was Updated",
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
        public async Task<CommandResponse> Handle(UpdateEventAreaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.UnitOfWork.EventAreaRepository.Update(request.ProjectedAs<EventArea>());

                // this.Logger.Info($"Change in db table {typeof(Area).Name} : {returnValue} entities");
                var retResp = new CommandResponse
                {
                    IsSuccess = true,
                    Message = "Entity was Updated",
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
        public async Task<CommandResponse> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.UnitOfWork.EventRepository.Update(request.ProjectedAs<Event>());

                // this.Logger.Info($"Change in db table {typeof(Area).Name} : {returnValue} entities");
                var retResp = new CommandResponse
                {
                    IsSuccess = true,
                    Message = "Entity was Updated",
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
        public async Task<CommandResponse> Handle(UpdateEventSeatCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.UnitOfWork.EventSeatRepository.Update(request.ProjectedAs<EventSeat>());

                // this.Logger.Info($"Change in db table {typeof(Area).Name} : {returnValue} entities");
                var retResp = new CommandResponse
                {
                    IsSuccess = true,
                    Message = "Entity was Updated",
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
        public async Task<CommandResponse> Handle(UpdateLayoutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.UnitOfWork.LayoutRepository.Update(request.ProjectedAs<Layout>());

                // this.Logger.Info($"Change in db table {typeof(Area).Name} : {returnValue} entities");
                var retResp = new CommandResponse
                {
                    IsSuccess = true,
                    Message = "Entity was Updated",
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
        public async Task<CommandResponse> Handle(UpdateSeatCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.UnitOfWork.SeatRepository.Update(request.ProjectedAs<Seat>());

                // this.Logger.Info($"Change in db table {typeof(Area).Name} : {returnValue} entities");
                var retResp = new CommandResponse
                {
                    IsSuccess = true,
                    Message = "Entity was Updated",
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
        public async Task<CommandResponse> Handle(UpdateVenueCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.UnitOfWork.VenueRepository.Update(request.ProjectedAs<Venue>());

                // this.Logger.Info($"Change in db table {typeof(Area).Name} : {returnValue} entities");
                var retResp = new CommandResponse
                {
                    IsSuccess = true,
                    Message = "Entity was Updated",
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