namespace SuperTicketApi.ApiEndpoint.Extension
{
    using Microsoft.Extensions.Options;

    using SuperTicketApi.ApiSettings.JsonSettings.Api;

    /// <inheritdoc />
    internal class ApplicationAccessRepository : IApplicationAccessRepository
    {
        private readonly IOptions<ApiKeyAccessSettings> _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationAccessRepository"/> class.
        /// </summary>
        public ApplicationAccessRepository(IOptions<ApiKeyAccessSettings> options)
        {
            this._options = options;
        }

        /// <inheritdoc />
        public bool CheckValidApiKey(string apiKey)
        {
            return this._options.Value.ValidKeys.Contains(apiKey);
        }
    }
}