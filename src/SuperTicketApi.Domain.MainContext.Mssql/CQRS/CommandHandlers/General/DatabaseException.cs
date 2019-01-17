namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.CommandHandlers.General
{
    using System;

    public class DatabaseException : Exception
    {
        public DatabaseException(string message)
            : base(message)
        {
        }

        public DatabaseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public DatabaseException(DataBaseErrors message)
            : base($"Procedure:{ message.ErrorProcedure}|" +
                    $"Error Number:{message.ErrorNumber}|" +
                    $"Error State:{message.ErrorState}|" +
                    $"Error Line:{message.ErrorLine}|" +
                    $"Error Severity:{message.ErrorSeverity}||" +
                    $"Message:{message.ErrorMessage}")
        {
        }
    }
}
