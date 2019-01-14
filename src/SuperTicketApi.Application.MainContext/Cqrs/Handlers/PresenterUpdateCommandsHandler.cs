namespace SuperTicketApi.Application.MainContext.Cqrs.Handlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using SuperTicketApi.Application.BoundedContext.DTO.Dto;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Update;
    using SuperTicketApi.Application.Seedwork;
    using SuperTicketApi.Domain.MainContext.Command.Update;

    /// <summary>
    /// Area command for presenter Layer
    /// </summary>
    public class PresenterUpdateCommandsHandler :
        BaseApplicationHandler,
        IRequestHandler<PresenterUpdateAreaCommand, CommandResponse>,
        IRequestHandler<PresenterUpdateEventAreaCommand, CommandResponse>,
        IRequestHandler<PresenterUpdateEventCommand, CommandResponse>,
        IRequestHandler<PresenterUpdateEventSeatCommand, CommandResponse>,
        IRequestHandler<PresenterUpdateLayoutCommand, CommandResponse>,
        IRequestHandler<PresenterUpdateSeatCommand, CommandResponse>,
        IRequestHandler<PresenterUpdateVenueCommand, CommandResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PresenterCreateCommandsHandler"/> class. 
        /// </summary>
        /// <param name="mediatr">
        /// The mediatr.
        /// </param>
        public PresenterUpdateCommandsHandler(IMediator mediatr) : base(mediatr)
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
        public async Task<CommandResponse> Handle(PresenterUpdateAreaCommand request, CancellationToken cancellationToken)
        {
            try
            {
               /* AreasValidator validator = new AreasValidator(this.Mediatr);
                ValidationResult validationResult = validator.Validate(request);

                if (!validationResult.IsValid)
                {
                    var resp = new CommandResponse
                    {
                        Message = "One or more validation errors occurred.",
                        ValidationErrors = validationResult.Errors
                    };
                    return resp;
                }
                */
                // ! todo create map from CreateAreaVM to map area database
                var dalCommand = request.ProjectedAs<UpdateAreaDomainCommand>();
                dalCommand.SwitchToAdminMode();
                // ! then call create area command from database level
                var commRes = await this.Mediatr.Send(dalCommand);

                // ! then geet seponse from DAL, and send created ID to Presenter
                if (commRes.IsSuccess)
                {
                    var dtoResp = commRes.Object.ProjectedAs<AreaDto>();

                    var resp = new CommandResponse
                    {
                        IsSuccess = true,
                        Message = "new entity in Area Table was added",
                        Object = dtoResp
                    };
                    return resp;
                }
                else
                {
                    var resp = new CommandResponse
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

                return new CommandResponse { Message = ex.Message };
            }
        }

        /// <inheritdoc />
        public async Task<CommandResponse> Handle(PresenterUpdateEventAreaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                /*
                 AreasValidator validator = new AreasValidator(this.Mediatr);
                 ValidationResult validationResult = validator.Validate(request);

                  if (!validationResult.IsValid)
                  {
                      var resp = new CommandResponse
                      {
                          Message = "One or more validation errors occurred.",
                          ValidationErrors = validationResult.Errors
                      };
                      return resp;
                  }  
                  */

                // ! todo create map from CreateAreaVM to map area database
                var dalCommand = request.ProjectedAs<UpdateEventAreaDomainCommand>();
                 dalCommand.SwitchToAdminMode();
                // ! then call create area command from database level
                var commRes = await this.Mediatr.Send(dalCommand);

                // ! then geet seponse from DAL, and send created ID to Presenter
                if (commRes.IsSuccess)
                {
                    var dtoResp = commRes.Object.ProjectedAs<EventAreaDto>();

                    var resp = new CommandResponse
                    {
                        IsSuccess = true,
                        Message = "new entity in Area Table was added",
                        Object = dtoResp
                    };
                    return resp;
                }
                else
                {
                    var resp = new CommandResponse
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
                return new CommandResponse { Message = ex.Message };
            }
        }

        /// <inheritdoc />
        public async Task<CommandResponse> Handle(PresenterUpdateEventCommand request, CancellationToken cancellationToken)
        {
            try
            {
                /*
                AreasValidator validator = new AreasValidator(this.Mediatr);
                ValidationResult validationResult = validator.Validate(request);

                if (!validationResult.IsValid)
                {
                    var resp = new CommandResponse
                    {
                        Message = "One or more validation errors occurred.",
                        ValidationErrors = validationResult.Errors
                    };
                    return resp;
                }
                */

                // ! todo create map from CreateAreaVM to map area database
                var dalCommand = request.ProjectedAs<UpdateEventDomainCommand>();
                 dalCommand.SwitchToAdminMode();
                // ! then call create area command from database level
                var commRes = await this.Mediatr.Send(dalCommand);

                // ! then geet seponse from DAL, and send created ID to Presenter
                if (commRes.IsSuccess)
                {
                    var dtoResp = commRes.Object.ProjectedAs<EventDto>();

                    var resp = new CommandResponse
                    {
                        IsSuccess = true,
                        Message = "new entity in Area Table was added",
                        Object = dtoResp
                    };
                    return resp;
                }
                else
                {
                    var resp = new CommandResponse
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
                return new CommandResponse { Message = ex.Message };
            }
        }

        /// <inheritdoc />
        public async Task<CommandResponse> Handle(PresenterUpdateEventSeatCommand request, CancellationToken cancellationToken)
        {
            try
            {
                /*
                AreasValidator validator = new AreasValidator(this.Mediatr);
                ValidationResult validationResult = validator.Validate(request);

                if (!validationResult.IsValid)
                {
                    var resp = new CommandResponse
                    {
                        Message = "One or more validation errors occurred.",
                        ValidationErrors = validationResult.Errors
                    };
                    return resp;
                }
                */

                // ! todo create map from CreateAreaVM to map area database
                var dalCommand = request.ProjectedAs<UpdateEventSeatDomainCommand>();
                 dalCommand.SwitchToAdminMode();
                // ! then call create area command from database level
                var commRes = await this.Mediatr.Send(dalCommand);

                // ! then geet seponse from DAL, and send created ID to Presenter
                if (commRes.IsSuccess)
                {
                    var dtoResp = commRes.Object.ProjectedAs<EventSeatDto>();

                    var resp = new CommandResponse
                    {
                        IsSuccess = true,
                        Message = "new entity in Area Table was added",
                        Object = dtoResp
                    };
                    return resp;
                }
                else
                {
                    var resp = new CommandResponse
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
                return new CommandResponse { Message = ex.Message };
            }
        }

        /// <inheritdoc />
        public async Task<CommandResponse> Handle(PresenterUpdateLayoutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                /*
                AreasValidator validator = new AreasValidator(this.Mediatr);
                ValidationResult validationResult = validator.Validate(request);

                if (!validationResult.IsValid)
                {
                    var resp = new CommandResponse
                    {
                        Message = "One or more validation errors occurred.",
                        ValidationErrors = validationResult.Errors
                    };
                    return resp;
                }
                */

                // ! todo create map from CreateAreaVM to map area database
                var dalCommand = request.ProjectedAs<UpdateLayoutDomainCommand>();
                 dalCommand.SwitchToAdminMode();
                // ! then call create area command from database level
                var commRes = await this.Mediatr.Send(dalCommand);

                // ! then geet seponse from DAL, and send created ID to Presenter
                if (commRes.IsSuccess)
                {
                    var dtoResp = commRes.Object.ProjectedAs<LayoutDto>();

                    var resp = new CommandResponse
                    {
                        IsSuccess = true,
                        Message = commRes.Message,
                        Object = dtoResp
                    };
                    return resp;
                }
                else
                {
                    var resp = new CommandResponse
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

                return new CommandResponse { Message = ex.Message };
            }
        }

        /// <inheritdoc />
        public async Task<CommandResponse> Handle(PresenterUpdateSeatCommand request, CancellationToken cancellationToken)
        {
            try
            {
                /*
                AreasValidator validator = new AreasValidator(this.Mediatr);
                ValidationResult validationResult = validator.Validate(request);

                if (!validationResult.IsValid)
                {
                    var resp = new CommandResponse
                    {
                        Message = "One or more validation errors occurred.",
                        ValidationErrors = validationResult.Errors
                    };
                    return resp;
                }
                */

                // ! todo create map from CreateAreaVM to map area database
                var dalCommand = request.ProjectedAs<UpdateSeatDomainCommand>();
                 dalCommand.SwitchToAdminMode();
                // ! then call create area command from database level
                var commRes = await this.Mediatr.Send(dalCommand);

                // ! then geet seponse from DAL, and send created ID to Presenter
                if (commRes.IsSuccess)
                {
                    var dtoResp = commRes.Object.ProjectedAs<SeatDto>();

                    var resp = new CommandResponse
                    {
                        IsSuccess = true,
                        Message = commRes.Message,
                        Object = dtoResp
                    };
                    return resp;
                }
                else
                {
                    var resp = new CommandResponse
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

                return new CommandResponse { Message = ex.Message };
            }
        }

        /// <inheritdoc />
        public async Task<CommandResponse> Handle(PresenterUpdateVenueCommand request, CancellationToken cancellationToken)
        {
            try
            {
                /*
                AreasValidator validator = new AreasValidator(this.Mediatr);
                ValidationResult validationResult = validator.Validate(request);

                if (!validationResult.IsValid)
                {
                    var resp = new CommandResponse
                    {
                        Message = "One or more validation errors occurred.",
                        ValidationErrors = validationResult.Errors
                    };
                    return resp;
                }
                */

                // ! todo create map from CreateAreaVM to map area database
                var dalCommand = request.ProjectedAs<UpdateVenueDomainCommand>();
                 dalCommand.SwitchToAdminMode();
                // ! then call create area command from database level
                var commRes = await this.Mediatr.Send(dalCommand);

                // ! then geet seponse from DAL, and send created ID to Presenter
                if (commRes.IsSuccess)
                {
                    var dtoResp = commRes.Object.ProjectedAs<VenueDto>();

                    var resp = new CommandResponse
                    {
                        IsSuccess = true,
                        Message = commRes.Message,
                        Object = dtoResp
                    };
                    return resp;
                }
                else
                {
                    var resp = new CommandResponse
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
                return new CommandResponse { Message = ex.Message };
            }
        }
    }
}
