namespace SuperTicketApi.ApiEndpoint.Extension
{
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    using Newtonsoft.Json;

    /// <summary>
    /// Extensions for working directly with <see cref="HttpContext"/>
    /// </summary>
    public static class HttpContextExtnesions
    {
        private const string JsonContentType = "application/json; charset=utf-8";

        /// <summary>
        /// Write an <see cref="ApiError"/>
        /// </summary>
        public static Task WriteErrorAsync(
            this HttpContext context,
            ApiError error,
            HttpStatusCode responseCode = HttpStatusCode.BadRequest)
        {
            var errorJson = JsonConvert.SerializeObject(error);
            context.Response.StatusCode = (int)responseCode;
            context.Response.ContentType = JsonContentType;
            return context.Response.WriteAsync(errorJson);
        }
    }
}