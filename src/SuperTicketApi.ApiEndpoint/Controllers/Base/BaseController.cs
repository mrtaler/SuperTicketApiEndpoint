namespace SuperTicketApi.ApiEndpoint.Controllers.Base
{
    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Base controller with mediatr
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// In process messaging service. Glue between layers of the application
        /// </summary>
        protected IMediator Mediator { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public BaseController(IMediator mediator
            //IOptions<AppConnectionStrings> options,
            ) => this.Mediator = mediator;

    }
}
