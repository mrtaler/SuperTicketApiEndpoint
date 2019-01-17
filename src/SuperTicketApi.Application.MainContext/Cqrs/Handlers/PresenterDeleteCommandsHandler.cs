namespace SuperTicketApi.Application.MainContext.Cqrs.Handlers
{
    using MediatR;
    using SuperTicketApi.Application.BoundedContext.DTO.Dto;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Delete;
    using SuperTicketApi.Application.Seedwork;
    using SuperTicketApi.Domain.MainContext.Command.Delete;
    using System;
    using System.Threading;
    using System.Threading.Tasks;


    public class PresenterDeleteCommandsHandler :
        BaseApplicationHandler,
        IRequestHandler<PresenterDeleteAreaCommand, ApplicationCommandResponse>,
        IRequestHandler<PresenterDeleteEventAreaCommand, ApplicationCommandResponse>,
        IRequestHandler<PresenterDeleteEventCommand, ApplicationCommandResponse>,
        IRequestHandler<PresenterDeleteEventSeatCommand, ApplicationCommandResponse>,
        IRequestHandler<PresenterDeleteLayoutCommand, ApplicationCommandResponse>,
        IRequestHandler<PresenterDeleteSeatCommand, ApplicationCommandResponse>,
        IRequestHandler<PresenterDeleteVenueCommand, ApplicationCommandResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PresenterCreateCommandsHandler"/> class. 
        /// </summary>
        /// <param name="mediatr">
        /// The mediatr.
        /// </param>
        public PresenterDeleteCommandsHandler(IMediator mediatr) : base(mediatr)
        {
        }

        /// <summary>
        /// The handle.
        /// </summary>
        /// <param name="request">
        /// The <paramref name="request"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<ApplicationCommandResponse> Handle(
            PresenterDeleteAreaCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // ! todo create map from CreateAreaVM to map area database
                var dalCommand = request.ProjectedAs<DeleteAreaDomainCommand>();
                // ! then call create area command from database level
                var commRes = await this.Mediatr.Send(dalCommand);

                // ! then geet seponse from DAL, and send created ID to Presenter
                if (commRes.IsSuccess)
                {
                    var dtoResp = commRes.Object.ProjectedAs<AreaDto>();

                    var resp = new ApplicationCommandResponse
                    {
                        IsSuccess = true,
                        Message = "new entity in Area Table was added",
                        Object = dtoResp
                    };
                    return resp;
                }
                else
                {
                    var resp = new ApplicationCommandResponse
                    {
                        IsSuccess = false,
                        Message = commRes.Message,
                        Object = commRes.Object,
                    };
                    return resp;
                }
            }
            catch (Exception ex)
            {

                return new ApplicationCommandResponse { Message = ex.Message };
            }
        }

        /// <inheritdoc />
        public async Task<ApplicationCommandResponse> Handle(PresenterDeleteEventAreaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // ! todo create map from CreateAreaVM to map area database
                var dalCommand = request.ProjectedAs<DeleteEventAreaDomainCommand>();

                // ! then call create area command from database level
                var commRes = await this.Mediatr.Send(dalCommand);

                // ! then geet seponse from DAL, and send created ID to Presenter
                if (commRes.IsSuccess)
                {
                    var dtoResp = commRes.Object.ProjectedAs<EventAreaDto>();

                    var resp = new ApplicationCommandResponse
                    {
                        IsSuccess = true,
                        Message = "new entity in Area Table was added",
                        Object = dtoResp
                    };
                    return resp;
                }
                else
                {
                    var resp = new ApplicationCommandResponse
                    {
                        IsSuccess = false,
                        Message = commRes.Message,
                        Object = commRes.Object,
                    };
                    return resp;
                }
            }
            catch (Exception ex)
            {
                return new ApplicationCommandResponse { Message = ex.Message };
            }
        }

        /// <inheritdoc />
        public async Task<ApplicationCommandResponse> Handle(PresenterDeleteEventCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // ! todo create map from CreateAreaVM to map area database
                var dalCommand = request.ProjectedAs<DeleteEventDomainCommand>();

                // ! then call create area command from database level
                var commRes = await this.Mediatr.Send(dalCommand);

                // ! then geet seponse from DAL, and send created ID to Presenter
                if (commRes.IsSuccess)
                {
                    var dtoResp = commRes.Object.ProjectedAs<EventDto>();

                    var resp = new ApplicationCommandResponse
                    {
                        IsSuccess = true,
                        Message = "new entity in Area Table was added",
                        Object = dtoResp
                    };
                    return resp;
                }
                else
                {
                    var resp = new ApplicationCommandResponse
                    {
                        IsSuccess = false,
                        Message = commRes.Message,
                        Object = commRes.Object,
                    };
                    return resp;
                }
            }
            catch (Exception ex)
            {
                return new ApplicationCommandResponse { Message = ex.Message };
            }
        }

        /// <inheritdoc />
        public async Task<ApplicationCommandResponse> Handle(PresenterDeleteEventSeatCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // ! todo create map from CreateAreaVM to map area database
                var dalCommand = request.ProjectedAs<DeleteEventSeatDomainCommand>();

                // ! then call create area command from database level
                var commRes = await this.Mediatr.Send(dalCommand);

                // ! then geet seponse from DAL, and send created ID to Presenter
                if (commRes.IsSuccess)
                {
                    var dtoResp = commRes.Object.ProjectedAs<EventSeatDto>();

                    var resp = new ApplicationCommandResponse
                    {
                        IsSuccess = true,
                        Message = "new entity in Area Table was added",
                        Object = dtoResp
                    };
                    return resp;
                }
                else
                {
                    var resp = new ApplicationCommandResponse
                    {
                        IsSuccess = false,
                        Message = commRes.Message,
                        Object = commRes.Object,
                    };
                    return resp;
                }
            }
            catch (Exception ex)
            {
                return new ApplicationCommandResponse { Message = ex.Message };
            }
        }

        /// <inheritdoc />
        public async Task<ApplicationCommandResponse> Handle(PresenterDeleteLayoutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // ! todo create map from CreateAreaVM to map area database
                var dalCommand = request.ProjectedAs<DeleteLayoutDomainCommand>();

                // ! then call create area command from database level
                var commRes = await this.Mediatr.Send(dalCommand);

                // ! then geet seponse from DAL, and send created ID to Presenter
                if (commRes.IsSuccess)
                {
                    var dtoResp = commRes.Object.ProjectedAs<LayoutDto>();

                    var resp = new ApplicationCommandResponse
                    {
                        IsSuccess = true,
                        Message = commRes.Message,
                        Object = dtoResp
                    };
                    return resp;
                }
                else
                {
                    var resp = new ApplicationCommandResponse
                    {
                        IsSuccess = false,
                        Message = commRes.Message,
                        Object = commRes.Object,
                    };
                    return resp;
                }
            }
            catch (Exception ex)
            {

                return new ApplicationCommandResponse { Message = ex.Message };
            }
        }

        /// <inheritdoc />
        public async Task<ApplicationCommandResponse> Handle(PresenterDeleteSeatCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // ! todo create map from CreateAreaVM to map area database
                var dalCommand = request.ProjectedAs<DeleteSeatDomainCommand>();

                // ! then call create area command from database level
                var commRes = await this.Mediatr.Send(dalCommand);

                // ! then geet seponse from DAL, and send created ID to Presenter
                if (commRes.IsSuccess)
                {
                    var dtoResp = commRes.Object.ProjectedAs<SeatDto>();

                    var resp = new ApplicationCommandResponse
                    {
                        IsSuccess = true,
                        Message = commRes.Message,
                        Object = dtoResp
                    };
                    return resp;
                }
                else
                {
                    var resp = new ApplicationCommandResponse
                    {
                        IsSuccess = false,
                        Message = commRes.Message,
                        Object = commRes.Object,
                    };
                    return resp;
                }
            }
            catch (Exception ex)
            {

                return new ApplicationCommandResponse { Message = ex.Message };
            }
        }

        /// <inheritdoc />
        public async Task<ApplicationCommandResponse> Handle(PresenterDeleteVenueCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // ! todo create map from CreateAreaVM to map area database
                var dalCommand = request.ProjectedAs<DeleteVenueDomainCommand>();

                // ! then call create area command from database level
                var commRes = await this.Mediatr.Send(dalCommand);

                // ! then geet seponse from DAL, and send created ID to Presenter
                if (commRes.IsSuccess)
                {
                    var dtoResp = commRes.Object.ProjectedAs<VenueDto>();

                    var resp = new ApplicationCommandResponse
                    {
                        IsSuccess = true,
                        Message = commRes.Message,
                        Object = dtoResp
                    };
                    return resp;
                }
                else
                {
                    var resp = new ApplicationCommandResponse
                    {
                        IsSuccess = false,
                        Message = commRes.Message,
                        Object = commRes.Object,
                    };
                    return resp;
                }
            }
            catch (Exception ex)
            {
                return new ApplicationCommandResponse { Message = ex.Message };
            }
        }
    }
}
