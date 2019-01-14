﻿namespace SuperTicketApi.ApiEndpoint.Controllers
{
    using System.Threading.Tasks;

    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    using SuperTicketApi.ApiEndpoint.Controllers.Base;
    using SuperTicketApi.ApiEndpoint.ViewModel;
    using SuperTicketApi.ApiEndpoint.ViewModel.Layout;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Create;
    using SuperTicketApi.Domain.MainContext.Queries;
    using SuperTicketApi.Domain.MainContext.Queries.GetSingleDomainEntity;

    /// <summary>
    /// The Test controller.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{api-version:apiVersion}/[controller]")]
    public class LayoutController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public LayoutController(IMediator mediator)
            : base(mediator)
        {
        }

        /// <summary>
        /// Gets all layouts.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllLayouts")]
        public async Task<IActionResult> GetAllLayouts()
        {
            var layouts = await this.Mediator.Send(EnumerableQueryPattern.GetLayoutAsIEnumerableQuery);
            return new ObjectResult(new
            {
                layouts = layouts,
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
            var result = await this.Mediator.Send(ByIdSingleQueryPattern.GetSingleLayoutQuery(id));
            return new ObjectResult(new { Layout = result });
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
        public async Task<IActionResult> Post([FromBody] CreateLayoutViewModel createViewModel)
        {
           var result = await this.Mediator.Send(
                            createViewModel.ProjectedAs<PresenterCreateLayoutCommand>());
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
