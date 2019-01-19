namespace SuperTicketApi.ApiEndpoint.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using SuperTicketApi.ApiEndpoint.Controllers.Base;
    using SuperTicketApi.ApiSettings.JsonSettings.ConnectionStrings;
    using System.Threading.Tasks;

    [ApiVersion("1.0")]
    [Route("api/v{api-version:apiVersion}/[controller]")]
    public class SettingsController : BaseController
    {
        IOptionsSnapshot<ConnectionStrings> connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="AreaController"/> class.
        /// </summary>
        /// <param name="mediator">
        /// The mediator.
        /// </param>
        public SettingsController(IMediator mediator,
            IOptionsSnapshot<ConnectionStrings> connectionString)
            : base(mediator)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// The GET api/values 
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet("GetAllAreas")]
        public async Task<IActionResult> GetSettings()
        {
            var currentConnectionString = connectionString.Value.ConnectionString.Split(';')[0];


            return new ObjectResult(new { ConnectionString = currentConnectionString });
        }
    }
}