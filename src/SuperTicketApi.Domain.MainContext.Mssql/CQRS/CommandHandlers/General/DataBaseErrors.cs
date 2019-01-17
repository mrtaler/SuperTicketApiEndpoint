namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.CommandHandlers.General
{
    using System.Data;

    /// <summary>
    /// The DataBase errors.
    /// </summary>
    public class DataBaseErrors
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataBaseErrors"/> class.
        /// </summary>
        /// <param name="reader">
        /// The reader.
        /// </param>
        public DataBaseErrors(IDataReader reader)
        {
            this.ErrorNumber = reader.GetTypedValue<string>("ErrorNumber");
            this.ErrorSeverity = reader.GetTypedValue<string>("ErrorSeverity");
            this.ErrorState = reader.GetTypedValue<string>("ErrorState");
            this.ErrorProcedure = reader.GetTypedValue<string>("ErrorProcedure");
            this.ErrorLine = reader.GetTypedValue<string>("ErrorLine");
            this.ErrorMessage = reader.GetTypedValue<string>("ErrorMessage");
        }

        /// <summary>
        /// Gets the error number.
        /// = GetItem("ErrorNumber", com);
        /// </summary>
        public string ErrorNumber { get; }

        /// <summary>
        /// Gets the error severity.
        /// GetItem("ErrorSeverity", com);
        /// </summary>
        public string ErrorSeverity { get; }

        /// <summary>
        /// Gets the error state.
        /// GetItem("ErrorState", com);
        /// </summary>
        public string ErrorState { get; }

        /// <summary>
        /// Gets the error procedure.
        /// GetItem("ErrorProcedure", com);
        /// </summary>
        public string ErrorProcedure { get; }

        /// <summary>
        /// Gets the error line.
        /// GetItem("ErrorLine", com);
        /// </summary>
        public string ErrorLine { get; }

        /// <summary>
        /// Gets the error message.
        /// GetItem("ErrorMessage", com);
        /// </summary>
        public string ErrorMessage { get; }
    }
}