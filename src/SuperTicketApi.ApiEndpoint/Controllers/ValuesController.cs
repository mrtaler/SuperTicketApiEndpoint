namespace SuperTicketApi.ApiEndpoint.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Options;

    using SuperTicketApi.ApiSettings.JsonSettings.ConnectionStrings;

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
        public ValuessssssssssController(/*IEventService serv*/
            IOptions<AppConnectionStrings> options, IHostingEnvironment env)
        {
            this.env = env;
            opt = options;
            // var tt = serv.GetAll();
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

            return new ObjectResult(new
            {
                ConnectionsString = opt.Value.MssqlConnectionString,
                ASPNETCORE_ENVIRONMENT = env.EnvironmentName
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
