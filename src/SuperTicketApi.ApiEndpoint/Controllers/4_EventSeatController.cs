﻿namespace SuperTicketApi.ApiEndpoint.Controllers
{
    using System.Threading.Tasks;

    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    using SuperTicketApi.ApiEndpoint.Controllers.Base;
    using SuperTicketApi.ApiEndpoint.ViewModel;
    using SuperTicketApi.ApiEndpoint.ViewModel.EventSeat;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Create;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Delete;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Update;
    using SuperTicketApi.Domain.MainContext.Queries;

    /// <summary>
    /// The Test controller.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{api-version:apiVersion}/[controller]")]
    public class EventSeatController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventSeatController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public EventSeatController(IMediator mediator)
            : base(mediator)
        {
        }

        /// <summary>
        /// Gets all event seats.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllEventSeats")]
        public async Task<IActionResult> GetAllEventSeats()
        {
            var eventSeats = await this.Mediator.Send(EnumerableQueryPattern.GetEventSeatAsIEnumerableQuery);
            return new ObjectResult(new
            {
                eventSeats = eventSeats,
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
            var result = await this.Mediator.Send(ByIdSingleQueryPattern.GetSingleEventSeatQuery(id));
            return new ObjectResult(new { EventSeat = result });
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
        public async Task<IActionResult> Post([FromBody] CreateEventSeatViewModel createViewModel)
        {
            var command = createViewModel.ProjectedAs<PresenterCreateEventSeatCommand>();
           var result = await this.Mediator.Send(command);

            return this.GetResult(result);
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
         [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateEventSeatViewModel updateModel)
        {
            var result = await this.Mediator.Send(
                updateModel.ProjectedAs<PresenterUpdateEventSeatCommand>());

            return this.GetResult(result);
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
            var result = await this.Mediator.Send(new PresenterDeleteEventSeatCommand(id));

            return this.GetResult(result);
        }
    }
}
