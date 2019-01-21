namespace SuperTicketApi.ApiSettings.JsonSettings.ConnectionStrings
{
    public class ConnectionStrings
    {
        /* private IConfiguration config;
 
         public AppConnectionStrings()
         {
         }*/

        /*        public AppConnectionStrings(IConfiguration config)
                {
                    this.config = config;
                }*/

        /// <summary>
        /// The connection string to use.
        /// </summary>

        // public string ConnectionString { get; set; }
        public string ConnectionString { get; set; }

        // =>this.config.GetSection("AppConnectionStrings:MssqlConnectionString").Value;
        public string ProviderName { get; set; }
    }
}
