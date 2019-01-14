namespace SuperTicketApi.Domain.MainContext.Mssql.UnitOfWorks
{
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// The data factory.
    /// </summary>
    public static class DataFactory
    {
        /// <summary>
        /// The create connection.
        /// </summary>
        /// <param name="connectionString">
        /// The connection string.
        /// </param>
        /// <returns>
        /// The <see cref="IDbConnection"/>.
        /// </returns>
        public static SqlConnection CreateConnection(
            string connectionString)
        {
            var connection = new SqlConnection(connectionString);


            return connection;
        }
    }
}