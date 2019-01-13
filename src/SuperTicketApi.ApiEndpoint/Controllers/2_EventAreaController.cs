﻿namespace SuperTicketApi.ApiEndpoint.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using SuperTicketApi.ApiEndpoint.Controllers.Base;
    using SuperTicketApi.Domain.MainContext.Queries;
    using System.Threading.Tasks;

    using SuperTicketApi.ApiEndpoint.ViewModel;
    using SuperTicketApi.ApiEndpoint.ViewModel.EventArea;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Create;

    /// <summary>
    /// The Test controller.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{api-version:apiVersion}/[controller]")]
    public class EventAreaController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventAreaController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public EventAreaController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Gets all event areas.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllEventAreas")]
        public async Task<IActionResult> GetAllEventAreas()
        {
            var eventAreas = await this.Mediator.Send(EnumerableQueryPattern.GetEventAreaAsIEnumerableQuery);
            return new ObjectResult(new
            {
                eventAreas = eventAreas,
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
            var result = await this.Mediator.Send(ByIdSingleQueryPattern.GetSingleEventAreaQuery(id));
            return new ObjectResult(new { EventArea = result });
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
        public async Task<IActionResult> Post([FromBody] CreateEventAreaViewModel createViewModel)
        {
          var result = await this.Mediator.Send(
                           createViewModel.ProjectedAs<PresenterCreateEventAreaCommand>());
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
