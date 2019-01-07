using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTicketApi.ApiEndpoint.Cqrs.Commands.Area
{
    /// <summary>
    /// base query command Handler
    /// </summary>
    public class BasePresenterHandler
    {
        protected readonly IMediator mediatr;

        public BasePresenterHandler( IMediator mediatr)
        {
            this.mediatr = mediatr;
            Log.Information($"{this.GetType().Name} was started");
        }
    }
}
