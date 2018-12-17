namespace SuperTicketApi.ApiSettings.CorrelationIdOptions
{
    public class CorrelationIdOptions
    {
        /// <summary>
        /// The header field name where the correlation ID will be stored
        /// </summary>
        public string Header { get; set; } = "X-Correlation-ID";

        /// <summary>
        /// Specified flag on which client correlation id behavior could be suppressed and server could use custom behavior
        /// </summary>
        public bool UseCustomCorrelationId { get; set; }
    }
}
