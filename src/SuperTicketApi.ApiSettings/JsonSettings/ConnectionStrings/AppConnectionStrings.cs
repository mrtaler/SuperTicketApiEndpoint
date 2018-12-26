namespace SuperTicketApi.ApiSettings.JsonSettings.ConnectionStrings
{
    using Microsoft.Extensions.Configuration;

    public class AppConnectionStrings
    {
        private IConfiguration config;

        public AppConnectionStrings()
        {
        }

        public AppConnectionStrings(IConfiguration config)
        {
            this.config = config;
        }

        public string MssqlConnectionString => this.config.GetSection("AppConnectionStrings:MssqlConnectionString").Value;

        public string ProviderName { get; set; }
    }
}
