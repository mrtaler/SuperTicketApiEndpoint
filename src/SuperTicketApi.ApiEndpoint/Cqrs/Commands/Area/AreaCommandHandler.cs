using MediatR;
using SuperTicketApi.ApiEndpoint.Cqrs;
using SuperTicketApi.ApiEndpoint.Cqrs.Commands.Area;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuperTicketApi.DistributedServices.Seedwork.Cqrs.Commands.Area
{
    /// <summary>
    /// Area command for presenter Layer
    /// </summary>
    /// <seealso cref="BasePresenterHandler" />
    /// <seealso cref="MediatR.IRequestHandler{ApiEndpoint.Cqrs.Commands.Area.CreateAreaCommand, ApiEndpoint.Cqrs.CommandResponse}" />
    public class AreaCommandHandler : BasePresenterHandler,
       IRequestHandler<CreateAreaCommand, CommandResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AreaCommandHandler"/> class.
        /// </summary>
        /// <param name="mediatr">The mediatr.</param>
        public AreaCommandHandler(IMediator mediatr) : base(mediatr)
        {
        }

        public Task<CommandResponse> Handle(CreateAreaCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
