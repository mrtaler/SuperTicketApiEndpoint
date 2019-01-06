namespace SuperTicketApi.ApiEndpoint.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using SuperTicketApi.ApiSettings.JsonSettings.ConnectionStrings;
    using SuperTicketApi.Domain.MainContext.Queries;
    using System.Threading.Tasks;

    /// <summary>
    /// The Test controller.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{api-version:apiVersion}/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private IHostingEnvironment env;

        private IOptions<AppConnectionStrings> opt;

        /// <summary>
        /// In process messaging service. Glue between layers of the application
        /// </summary>
        protected IMediator Mediator { get; set; }


        public TestController(
            IMediator mediator
            //IOptions<AppConnectionStrings> options,
            ) => this.Mediator = mediator;


        /// <summary>
        /// The GET api/values 
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet("GetAllAreas")]
        public async Task<IActionResult> GetAreas()
        {
            var areas = await Mediator.Send(EnumerableQueryes.GetAreaAsIEnumerableQuery);


            return new ObjectResult(new
            {
                areas = areas,
            });
        }

        /// <summary>
        /// Gets all event areas.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllEventAreas")]
        public async Task<IActionResult> GetAllEventAreas()
        {
            var eventAreas = await Mediator.Send(EnumerableQueryes.GetEventAreaAsIEnumerableQuery);
            return new ObjectResult(new
            {
                eventAreas = eventAreas,
            });
        }
        
        /// <summary>
        /// Gets all events.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllEvents")]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await Mediator.Send(EnumerableQueryes.GetEventAsIEnumerableQuery);
            return new ObjectResult(new
            {
                events = events,
            });
        }

        /// <summary>
        /// Gets all event seats.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllEventSeats")]
        public async Task<IActionResult> GetAllEventSeats()
        {
            var eventSeats = await Mediator.Send(EnumerableQueryes.GetEventSeatAsIEnumerableQuery);
            return new ObjectResult(new
            {
                eventSeats = eventSeats,
            });
        }

        /// <summary>
        /// Gets all layouts.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllLayouts")]
        public async Task<IActionResult> GetAllLayouts()
        {
            var layouts = await Mediator.Send(EnumerableQueryes.GetLayoutAsIEnumerableQuery);
            return new ObjectResult(new
            {
                layouts = layouts,
            });
        }

        /// <summary>
        /// Ges the get all seatst.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllSeats")]
        public async Task<IActionResult> GeGetAllSeatst()
        {
            var seats = await Mediator.Send(EnumerableQueryes.GetSeatAsIEnumerableQuery);
            return new ObjectResult(new
            {
                seats = seats,
            });
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
        /*
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
        public ActionResult<string> Get(int id)
        {
            return $"value {id}";
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
        }*/
    }
}
