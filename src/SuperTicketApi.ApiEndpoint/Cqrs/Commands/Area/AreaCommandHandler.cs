﻿using FluentValidation.Results;
using MediatR;
using SuperTicketApi.ApiEndpoint.Cqrs;
using SuperTicketApi.ApiEndpoint.Cqrs.Commands.Area;
using SuperTicketApi.Domain.MainContext.Command.CreateCommands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SuperTicketApi.DistributedServices.Seedwork.Cqrs.Commands.Area
{
    /// <summary>
    /// Area command for presenter Layer
    /// </summary>
    /// <seealso cref="BasePresenterHandler" />
    /// <seealso cref="MediatR.IRequestHandler{ApiEndpoint.Cqrs.Commands.Area.CreateAreaCommand, ApiEndpoint.Cqrs.CommandResponse}" />
    public class AreaPresenterCommandHandler : BasePresenterHandler,
       IRequestHandler<PresenterCreateAreaCommand, CommandResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AreaCommandHandler"/> class.
        /// </summary>
        /// <param name="mediatr">The mediatr.</param>
        public AreaPresenterCommandHandler(IMediator mediatr) : base(mediatr)
        {
        }


        public async Task<CommandResponse> Handle(
            PresenterCreateAreaCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                AreasValidator validator = new AreasValidator(this.mediatr);
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

                //! todo create map from CreateAreaVM to map area database
                var dalCommand = new CreateAreaCommand
                {
                    Description = request.Description,
                    LayoutId = request.LayoutId,
                    CoordX = request.CoordX,
                    CoordY = request.CoordY
                };

                //! then call create area command from database level
                var commRes = await mediatr.Send(dalCommand);
                //! then geet seponse from DAL, and send created ID to Presenter
                if (commRes.isSuccess)
                {
                    var resp = new CommandResponse
                    {
                        isSuccess = true,
                        Message = "new entity in Area Table was added",
                        Object = commRes.Object
                    };
                    return resp;
                }
                else
                {
                    var resp = new CommandResponse
                    {
                        isSuccess = false,
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
