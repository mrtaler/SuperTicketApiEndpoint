namespace SuperTicketApi.ApiEndpoint.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    using SuperTicketApi.ApiEndpoint.ViewModel;
    using SuperTicketApi.Domain.MainContext.Queries;
    using System.Threading.Tasks;

    using SuperTicketApi.ApiEndpoint.Controllers.Base;
    using SuperTicketApi.ApiEndpoint.ViewModel.Area;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Area;
    using SuperTicketApi.Domain.MainContext.Command.CreateCommands;

    /// <summary>
    /// The Test controller.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{api-version:apiVersion}/[controller]")]
    public class AreaController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AreaController"/> class. 
        /// </summary>
        /// <param name="mediator">
        /// The mediator.
        /// </param>
        public AreaController(
            IMediator mediator) : base(mediator)   // IOptions<AppConnectionStrings> options,
        {
        }


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
            var result = await Mediator.Send(ByIdSingleQueryes.GetSingleAreaQuery(id));

            return new ObjectResult(new { area = result });
        }

        /// <summary>
        /// The api/values
        /// </summary>
        /// <param name="createAreaViewModel">
        /// The create Area View Model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAreaViewModel createAreaViewModel)
        {
            
            var result = await Mediator.Send(createAreaViewModel.ProjectedAs<PresenterCreateAreaCommand>());

            if (result.isSuccess)
            {
                return new ObjectResult(new
                {
                    Success=result.isSuccess,
                    NewId = result.Object,
                });
            }

            return new ObjectResult(new
            {
                Success=result.isSuccess,
                Error = result.Message,

            });



        }

        /// <summary>
        /// The PUT api/values/5
        /// </summary>
        /// <param name="updateModel">
        /// The updated Model.
        /// </param>
        [HttpPut("{id}")]
        public async Task<IActionResult>  Put([FromBody] UpdateAreaViewModel updateModel)
        {
            var result = await Mediator.Send(
                updateModel.ProjectedAs<UpdateAreaCommand>());
            if (result.isSuccess)
            {
                return new ObjectResult(new
                {
                    Success = result.isSuccess,
                    NewId = result.Object,
                });
            }

            return new ObjectResult(new
            {
                Success = result.isSuccess,
                Error = result.Message,

            });

        }


        /// <summary>
        /// The DELETE api/values/5
        /// </summary>
        /// <param name="id">
        /// The <paramref name="id"/>.
        /// </param>
        [HttpDelete("{id}")]
          public async Task<IActionResult>  Delete(int id)
        {
            var result = await Mediator.Send(new DeleteAreaCommand(id));
            if (result.isSuccess)
            {
                return new ObjectResult(new
                {
                    Success = result.isSuccess,
                    NewId = result.Object,
                });
            }

            return new ObjectResult(new
            {
                Success = result.isSuccess,
                Error = result.Message,

            });
            
        }
    }
}
