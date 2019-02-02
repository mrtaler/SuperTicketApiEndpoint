namespace SuperTicketApi.ApiEndpoint.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using SuperTicketApi.ApiEndpoint.Controllers.Base;
    using SuperTicketApi.ApiSettings.JsonSettings.ConnectionStrings;
    using System.Threading.Tasks;

    /// <summary>
    /// The settings controller.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{api-version:apiVersion}/[controller]")]
    public class SettingsController : BaseController
    {
        /// <summary>
        /// The connection string.
        /// </summary>
        private readonly IOptionsSnapshot<ConnectionStrings> connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsController"/> class. 
        /// </summary>
        /// <param name="mediator">
        /// The mediator.
        /// </param>
        /// <param name="connectionString">
        /// The connection String.
        /// </param>
        public SettingsController(IMediator mediator, IOptionsSnapshot<ConnectionStrings> connectionString)
            : base(mediator)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// The get settings.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("GetAllAreas")]
        public async Task<IActionResult> GetSettings()
        {
            var currentConnectionString = this.connectionString.Value.ConnectionString.Split(';')[0];


            return new ObjectResult(new { ConnectionString = currentConnectionString });
        }
    }
}