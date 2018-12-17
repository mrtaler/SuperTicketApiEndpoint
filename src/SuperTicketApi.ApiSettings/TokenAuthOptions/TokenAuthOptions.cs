namespace SuperTicketApi.ApiSettings.TokenAuthOptions
{
    /// <summary>
    /// The token setup.
    /// </summary>
    public class TokenAuthOptions
    {
        /// <summary>
        /// Gets or sets the Token Issuer.
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Gets or sets the token consumer.
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Gets or sets the secret key.
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// Gets or sets the token life time in min
        /// </summary>
        public int TokenLifeTime { get; set; }
    }
}
