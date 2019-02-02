namespace SuperTicketApi.ApiEndpoint.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;

    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;

    using SuperTicketApi.ApiEndpoint.Controllers.Base;
    using SuperTicketApi.ApiEndpoint.ViewModel;
    using SuperTicketApi.ApiEndpoint.ViewModel.Area;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Create;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Delete;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Update;
    using SuperTicketApi.Domain.MainContext.Queries;

    /// <summary>
    /// The Test controller.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{api-version:apiVersion}/[controller]")]
    public class ServiceTestsController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AreaController"/> class.
        /// </summary>
        /// <param name="mediator">
        /// The mediator.
        /// </param>
        public ServiceTestsController(IMediator mediator)
            : base(mediator)
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
            var tt = new OAuthClient();
            return new ObjectResult(new { res = tt.GetAllAsync<IEnumerable<string>>() });
        }
    }

    public class OAuthClient : IOAuthClient
    {
        private string urlAPI;
        private readonly ISerializer deserializer;
        public OAuthClient(string urlApi = "http://localhost:9002/api/values")
        {
            this.urlAPI = urlApi;
            deserializer = new JsonSerializer();
        }

        /// <inheritdoc />
        public T GetAllAsync<T>()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = httpClient.GetAsync(urlAPI).Result;
                using (HttpContent content = response.Content)
                {
                    var data = content.ReadAsStringAsync().Result;
                    var result = deserializer.Deserialize<T>(data);
                    return result;
                }
            }
        }
    }



    public interface IOAuthClient
    {
        [HttpGet("/api/values")]
        T GetAllAsync<T>();
    }
    public interface ITask<TResult>
    {
        Task<TResult> InvokeAsync();
        TaskAwaiter<TResult> GetAwaiter();
        ConfiguredTaskAwaitable<TResult> ConfigureAwait(
            bool continueOnCapturedContext);
    }

    public interface IRestConnector
    {
        /// <summary>
        /// Gets deserialized response body from the specified endpoint using GET http method
        /// </summary>
        /// <param name="apiAddress">Address of the API endpoint</param>
        /// <typeparam name="TResponse">Response data type</typeparam>
        /// <returns>Deserialized response body</returns>
        TResponse Get<TResponse>(string apiAddress);
    }

    public interface ISerializer
    {
        string MimeType { get; }

        T Deserialize<T>(string content);

        string Serialize(object obj);
    }

    public class JsonSerializer : ISerializer
    {
        public string MimeType
        {
            get { return "application/json"; }
        }

        public T Deserialize<T>(string content)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(content);
            MemoryStream stream = new MemoryStream(byteArray);
            StreamReader reader = new StreamReader(stream);
            JsonTextReader jreader = new JsonTextReader(reader);
            var serializer = new Newtonsoft.Json.JsonSerializer();
            T result = serializer.Deserialize<T>(jreader);
            return result;
        }

        public string Serialize(object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj,
                Formatting.None,
                new JsonSerializerSettings
                {
                    DateFormatString = "yyyy-MM-ddThh:mm:ss"
                });

            ////string output;
            ////MemoryStream stream = new MemoryStream();
            ////using (TextWriter writer = new StreamWriter(stream))
            ////{
            ////    using (JsonTextWriter jwriter = new JsonTextWriter(writer))
            ////    {
            ////        var serializer = new Newtonsoft.Json.JsonSerializer();
            ////        serializer.Serialize(jwriter, obj);
            ////        jwriter.Flush();
            ////        stream.Position = 0;
            ////        using (StreamReader sr = new StreamReader(stream))
            ////        {
            ////            output = sr.ReadToEnd();
            ////        }
            ////    }
            ////}

            ////return output;
        }
    }
}