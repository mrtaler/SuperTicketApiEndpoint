namespace SuperTicketApi.ApiEndpoint.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using SuperTicketApi.ApiEndpoint.Controllers.Base;
    using SuperTicketApi.ApiEndpoint.ViewModel;
    using SuperTicketApi.ApiEndpoint.ViewModel.Venue;
    using SuperTicketApi.Domain.MainContext.Queries;
    using System.Threading.Tasks;

    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Create;

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
        public VenueController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// The get all venues.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("GetAllVenues")]
        public async Task<IActionResult> GetAllVenues()
        {
            var venues = await this.Mediator.Send(EnumerableQueryPattern.GetVenueAsIEnumerableQuery);

            return new ObjectResult(new
            {
                venues = venues
            });
        }

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
            var result = await this.Mediator.Send(ByIdSingleQueryPattern.GetSingleVenueQuery(id));
            return new ObjectResult(new { Venue = result });
        }

        /// <summary>
        /// The api/values
        /// </summary>
        /// <param name="createViewModel">
        /// The create View Model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateVenueViewModel createViewModel)
        {
            var result = await this.Mediator.Send(
                             createViewModel.ProjectedAs<PresenterCreateVenueCommand>());
            if (result.IsSuccess)
            {
                return new ObjectResult(new
                {
                    Success = result.IsSuccess,
                    NewEntity = result.Object,
                });
            }

            return new ObjectResult(new
            {
                Success = result.IsSuccess,
                Error = result.Message,
            });
        }

        ///// <summary>
        ///// The PUT api/values/5
        ///// </summary>
        ///// <param name="id">
        ///// The <paramref name="id"/>.
        ///// </param>
        ///// <param name="value">
        ///// The value.
        ///// </param>
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, [FromBody] string value)
        //{
        //}


        ///// <summary>
        ///// The DELETE api/values/5
        ///// </summary>
        ///// <param name="id">
        ///// The <paramref name="id"/>.
        ///// </param>
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //}
    }
}
