using System.Collections.Generic;

namespace SuperTicketApi.ApiSettings.JsonSettings.Api
{
    public class ApiKeyAccessSettings
    {
        /// <summary>
        /// The list of keys that will be accepted
        /// </summary>
        public List<string> ValidKeys { get; set; }
    }
}