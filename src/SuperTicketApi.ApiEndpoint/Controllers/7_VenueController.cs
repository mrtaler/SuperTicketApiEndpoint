namespace SuperTicketApi.ApiEndpoint.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using SuperTicketApi.Domain.MainContext.Queries;
    using SuperTicketApi.Domain.MainContext.Queries.GetSingleDomainEntity;
    using System.Threading.Tasks;

    using SuperTicketApi.ApiEndpoint.Controllers.Base;

    /// <summary>
    /// The Test controller.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{api-version:apiVersion}/[controller]")]
    public class VenueController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VenueController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public VenueController(
            IMediator mediator
            //IOptions<AppConnectionStrings> options,
            ) : base(mediator)
        {
        }


        /// <summary>
        /// Gets all venues.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllVenues")]
        public async Task<IActionResult> GetAllVenues()
        {
            var venues = await Mediator.Send(EnumerableQueryes.GetVenueAsIEnumerableQuery);

            return new ObjectResult(new
            {
                venues = venues
            });
        }

        //https://stackoverflow.com/questions/42360139/asp-net-core-return-json-with-status-code
        /// <summary>
        /// The GET api/values/5
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await Mediator.Send(ByIdSingleQueryes.GetSingleVenueQuery(id));
            return new ObjectResult(new { Venue = result });
        }

        /// <summary>
        /// The api/values
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult<string> Post([FromBody] string value)
        {
            return $"value is {value}";
        }

        /// <summary>
        /// The PUT api/values/5
        /// </summary>
        /// <param name="id">
        /// The <paramref name="id"/>.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


        /// <summary>
        /// The DELETE api/values/5
        /// </summary>
        /// <param name="id">
        /// The <paramref name="id"/>.
        /// </param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
