namespace SuperTicketApi.Domain.Seedwork
{
    using System.Data;

    public interface ISqlHelper
    {
        IDbConnection CreateConnection(string connectionString);

        IDataReader ExecuteReader(IDbConnection connection, string commandText, params Parameter[] parameters);

        IDataReader ExecuteReader(IDbConnection connection, string commandText, CommandType commandType, params Parameter[] parameters);

        int ExecuteNonQuery(IDbConnection connection, string commandText, params Parameter[] parameters);

        T ExecuteScalar<T>(IDbConnection connection, string commandText, params Parameter[] parameters);

        int ExecuteNonQuery(IDbConnection connection, string commandText, CommandType commandType, params Parameter[] parameters);
    }
}