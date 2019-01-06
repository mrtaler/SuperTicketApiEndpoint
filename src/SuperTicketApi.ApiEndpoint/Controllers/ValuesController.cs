namespace SuperTicketApi.ApiEndpoint.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using SuperTicketApi.ApiSettings.JsonSettings.ConnectionStrings;
    using SuperTicketApi.Domain.MainContext.Queries.GetListOfDomainEntity;
    using System.Linq;

    /// <summary>
    /// The values controller.
    /// </summary>
    [ApiVersion("1.0")]
    [ApiVersion("2.1")]
    [Route("api/v{api-version:apiVersion}/[controller]")]
    [ApiController]
    public class ValuessssssssssController : ControllerBase
    {
        private IHostingEnvironment env;

        private IOptions<AppConnectionStrings> opt;
        /// <summary>
        /// In process messaging service. Glue between layers of the application
        /// </summary>
        protected IMediator Mediator { get; set; }

        private AppConnectionStrings connectionStrings;
        public ValuessssssssssController(
            IMediator mediator,
            //IOptions<AppConnectionStrings> options,
            IHostingEnvironment env,
            AppConnectionStrings connectionStrings)
        {
            this.Mediator = mediator;
            this.env = env;
            //this.opt = options;
            this.connectionStrings = connectionStrings;


        }


        /// <summary>
        /// The GET api/values 
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet("GetEnvironmentVariable")]
        public IActionResult Get()
        {
            //  var tt = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var tt = Mediator.Send(new GetAreaAsIEnumerableQuery()).Result;
            var tt1 = tt.FirstOrDefault();
            return new ObjectResult(new
            {
                // ConnectionsStringFromIOptions = opt.Value.MssqlConnectionString,
                // connectionStringsFromAppConnectionStrings = connectionStrings.MssqlConnectionString,
                ASPNETCORE_ENVIRONMENT = env.EnvironmentName,
                GetAreaAsIEnumerableQueryResult = tt
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
        }
    }
}
