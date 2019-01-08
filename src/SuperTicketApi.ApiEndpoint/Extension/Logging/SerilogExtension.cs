namespace SuperTicketApi.ApiEndpoint.Extension.Logging
{
    using Serilog;

    /// <summary>
    /// The serilog extension.
    /// </summary>
    public static class SerilogExtension
    {
        /// <summary>
        /// The custom information.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="other">
        /// The other.
        /// </param>
        /// <param name="environment">
        /// The enviornment.
        /// </param>
        /// <param name="host">
        /// The host.
        /// </param>
        /// <param name="informationMessage">
        /// The information message.
        /// </param>
        public static void CustomInformation(
            this ILogger logger,
            string user = "",
            string other = "",
            string environment = "",
            string host = "",
            string informationMessage = "")
        {
            logger.ForContext(CustomColumn.User.ToString(), user)
                  .ForContext(CustomColumn.Other.ToString(), other)
                  .ForContext(CustomColumn.Environment.ToString(), environment)
                  .ForContext(CustomColumn.Host.ToString(), host)
                  .Information(informationMessage);
        }

        /// <summary>
        /// The custom warning.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="other">
        /// The other.
        /// </param>
        /// <param name="environment">
        /// The enviornment.
        /// </param>
        /// <param name="host">
        /// The host.
        /// </param>
        /// <param name="warningMessage">
        /// The warning message.
        /// </param>
        public static void CustomWarning(
            this ILogger logger,
            string user = "",
            string other = "",
            string environment = "",
            string host = "",
            string warningMessage = "")
        {
            logger.ForContext(CustomColumn.User.ToString(), user)
                  .ForContext(CustomColumn.Other.ToString(), other)
                  .ForContext(CustomColumn.Environment.ToString(), environment)
                  .ForContext(CustomColumn.Host.ToString(), host)
                  .Warning(warningMessage);
        }

        /// <summary>
        /// The custom error.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="other">
        /// The other.
        /// </param>
        /// <param name="environment">
        /// The enviornment.
        /// </param>
        /// <param name="host">
        /// The host.
        /// </param>
        /// <param name="errorMessage">
        /// The error message.
        /// </param>
        public static void CustomError(
            this ILogger logger,
            string user = "",
            string other = "",
            string environment = "",
            string host = "",
            string errorMessage = "")
        {
            logger.ForContext(CustomColumn.User.ToString(), user)
                  .ForContext(CustomColumn.Other.ToString(), other)
                  .ForContext(CustomColumn.Environment.ToString(), environment)
                  .ForContext(CustomColumn.Host.ToString(), host)
                  .Error(errorMessage);
        }

        /// <summary>
        /// The custom fatal.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="other">
        /// The other.
        /// </param>
        /// <param name="environment">
        /// The enviornment.
        /// </param>
        /// <param name="host">
        /// The host.
        /// </param>
        /// <param name="fatalMessage">
        /// The fatal message.
        /// </param>
        public static void CustomFatal(
            this ILogger logger,
            string user = "",
            string other = "",
            string environment = "",
            string host = "",
            string fatalMessage = "")
        {
            logger.ForContext(CustomColumn.User.ToString(), user)
                  .ForContext(CustomColumn.Other.ToString(), other)
                  .ForContext(CustomColumn.Environment.ToString(), environment)
                  .ForContext(CustomColumn.Host.ToString(), host)
                  .Fatal(fatalMessage);
        }
    }
}
