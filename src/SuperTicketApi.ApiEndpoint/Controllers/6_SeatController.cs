namespace SuperTicketApi.ApiEndpoint.Controllers
{
    using System.Threading.Tasks;

    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    using SuperTicketApi.ApiEndpoint.Controllers.Base;
    using SuperTicketApi.ApiEndpoint.ViewModel;
    using SuperTicketApi.ApiEndpoint.ViewModel.Seat;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Create;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Delete;
    using SuperTicketApi.Domain.MainContext.Queries;

    /// <summary>
    /// The Test controller.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{api-version:apiVersion}/[controller]")]
    public class SeatController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SeatController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public SeatController(IMediator mediator)
            : base(mediator)
        {
        }

        /// <summary>
        /// Ges the get all seatst.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllSeats")]
        public async Task<IActionResult> GeGetAllSeatst()
        {
            var seats = await this.Mediator.Send(EnumerableQueryPattern.GetSeatAsIEnumerableQuery);
            return new ObjectResult(new
            {
                seats = seats,
            });
        }

        // https://stackoverflow.com/questions/42360139/asp-net-core-return-json-with-status-code
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
            var result = await this.Mediator.Send(ByIdSingleQueryPattern.GetSingleSeatQuery(id));
            return new ObjectResult(new { Seat = result });
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
        public async Task<IActionResult> Post([FromBody] CreateSeatViewModel createViewModel)
        {
            var result = await this.Mediator.Send(
                             createViewModel.ProjectedAs<PresenterCreateSeatCommand>());
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

        /// <summary>
        /// The PUT api/values/5
        /// </summary>
        /// <param name="updateModel">
        /// The updated Model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IActionResult> Put([FromBody] UpdateSeatViewModel updateModel)
        {
            var result = await this.Mediator.Send(
                updateModel.ProjectedAs<PresenterUpdateSeatCommand>());
            if (result.IsSuccess)
            {
                return new ObjectResult(new
                {
                    Success = result.IsSuccess,
                    NewId = result.Object,
                });
            }

            return new ObjectResult(new
            {
                Success = result.IsSuccess,
                Error = result.Message,
            });
        }

        /// <summary>
        /// The DELETE api/values/5
        /// </summary>
        /// <param name="id">
        /// The <paramref name="id"/>.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.Mediator.Send(new PresenterDeleteSeatCommand(id));
            if (result.IsSuccess)
            {
                return new ObjectResult(new
                {
                    Success = result.IsSuccess,
                    NewId = result.Object,
                });
            }

            return new ObjectResult(new
            {
                Success = result.IsSuccess,
                Error = result.Message,
            });
        }
    }
}
