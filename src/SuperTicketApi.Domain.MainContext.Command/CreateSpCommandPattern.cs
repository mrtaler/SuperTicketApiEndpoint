namespace SuperTicketApi.Domain.MainContext.Command
{
    /// <summary>
    /// The create store procedure command pattern.
    /// </summary>
    public static class CreateSpCommandPattern
    {
        /// <summary>
        /// The create area Command
        /// </summary>
        public static string CreateArea => "[dbo].[CreateArea]";

        /// <summary>
        /// The create event Command
        /// </summary>
        public static string CreateEvent => "[dbo].[CreateEvent]";

        /// <summary>
        /// The create event area Command
        /// </summary>
        public static string CreateEventArea => "[dbo].[CreateEventArea]";

        /// <summary>
        /// The create event seat Command
        /// </summary>
        public static string CreateEventSeat => "[dbo].[CreateEventSeat]";

        /// <summary>
        /// The create layout Command
        /// </summary>
        public static string CreateLayout => "[dbo].[CreateLayout]";

        /// <summary>
        /// The create seat Command
        /// </summary>
        public static string CreateSeat => "[dbo].[CreateSeat]";

        /// <summary>
        /// The create venue Command
        /// </summary>
        public static string CreateVenue => "[dbo].[CreateVenue]";
    }
}