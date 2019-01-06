namespace SuperTicketApi.ApiEndpoint.Extension
{
    /// <summary>
    /// A repository for retrieving access settings
    /// </summary>
    public interface IApplicationAccessRepository
    {
        /// <summary>
        /// Checks if the API key is valid
        /// </summary>
        /// <param name="apiKey">The API key to check</param>
        /// <returns>true if key is valid</returns>
        bool CheckValidApiKey(string apiKey);
    }
}