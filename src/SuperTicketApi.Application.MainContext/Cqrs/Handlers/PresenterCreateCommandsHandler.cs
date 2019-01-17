namespace SuperTicketApi.Application.MainContext.Cqrs.Handlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using FluentValidation.Results;

    using MediatR;

    using SuperTicketApi.Application.BoundedContext.DTO.Dto;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Create;
    using SuperTicketApi.Application.MainContext.Cqrs.Validators;
    using SuperTicketApi.Application.Seedwork;
    using SuperTicketApi.Domain.MainContext.Command.CreateCommands;

    /// <summary>
    /// Area command for presenter Layer
    /// </summary>
    public class PresenterCreateCommandsHandler :
        BaseApplicationHandler,
        IRequestHandler<PresenterCreateAreaCommand, ApplicationCommandResponse>,
        IRequestHandler<PresenterCreateEventAreaCommand, ApplicationCommandResponse>,
        IRequestHandler<PresenterCreateEventCommand, ApplicationCommandResponse>,
        IRequestHandler<PresenterCreateEventSeatCommand, ApplicationCommandResponse>,
        IRequestHandler<PresenterCreateLayoutCommand, ApplicationCommandResponse>,
        IRequestHandler<PresenterCreateSeatCommand, ApplicationCommandResponse>,
        IRequestHandler<PresenterCreateVenueCommand, ApplicationCommandResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PresenterCreateCommandsHandler"/> class. 
        /// </summary>
        /// <param name="mediatr">
        /// The mediatr.
        /// </param>
        public PresenterCreateCommandsHandler(IMediator mediatr) : base(mediatr)
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
        public async Task<ApplicationCommandResponse> Handle(PresenterCreateAreaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                AreasValidator validator = new AreasValidator(this.Mediatr);
                ValidationResult validationResult = validator.Validate(request);

                if (!validationResult.IsValid)
                {
                    var resp = new ApplicationCommandResponse
                    {
                        Message = "One or more validation errors occurred.",
                        ValidationErrors = validationResult.Errors
                    };
                    return resp;
                }

                // ! todo create map from CreateAreaVM to map area database
                var dalCommand = request.ProjectedAs<CreateAreaDomainCommand>();

                //! then call create area command from database level
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
        public async Task<ApplicationCommandResponse> Handle(PresenterCreateEventAreaCommand request, CancellationToken cancellationToken)
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
                var dalCommand = request.ProjectedAs<CreateEventAreaDomainCommand>();

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
        public async Task<ApplicationCommandResponse> Handle(PresenterCreateEventCommand request, CancellationToken cancellationToken)
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
                var dalCommand = request.ProjectedAs<CreateEventDomainCommand>();

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
        public async Task<ApplicationCommandResponse> Handle(PresenterCreateEventSeatCommand request, CancellationToken cancellationToken)
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
                var dalCommand = request.ProjectedAs<CreateEventSeatDomainCommand>();

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
        public async Task<ApplicationCommandResponse> Handle(PresenterCreateLayoutCommand request, CancellationToken cancellationToken)
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
                var dalCommand = request.ProjectedAs<CreateLayoutDomainCommand>();

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
        public async Task<ApplicationCommandResponse> Handle(PresenterCreateSeatCommand request, CancellationToken cancellationToken)
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
                var dalCommand = request.ProjectedAs<CreateSeatDomainCommand>();

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
        public async Task<ApplicationCommandResponse> Handle(PresenterCreateVenueCommand request, CancellationToken cancellationToken)
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
                var dalCommand = request.ProjectedAs<CreateVenueDomainCommand>();

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
