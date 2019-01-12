namespace SuperTicketApi.Domain.MainContext.Command.CreateCommands
{
    /// <summary>
    /// The create store procedure command pattern.
    /// </summary>
    public static class CreateSpCommandPattern
    {
        /// <summary>
        /// The create area.
        /// </summary>
        public static string CreateArea => "[dbo].[CreateArea]";

        /// <summary>
        /// The create event.
        /// </summary>
        public static string CreateEvent => "[dbo].[CreateEvent]";

        /// <summary>
        /// The create event area.
        /// </summary>
        public static string CreateEventArea => "[dbo].[CreateEventArea]";

        /// <summary>
        /// The create event seat.
        /// </summary>
        public static string CreateEventSeat => "[dbo].[CreateEventSeat]";

        /// <summary>
        /// The create layout.
        /// </summary>
        public static string CreateLayout => "[dbo].[CreateLayout]";

        /// <summary>
        /// The create seat.
        /// </summary>
        public static string CreateSeat => "[dbo].[CreateSeat]";

        /// <summary>
        /// The create venue.
        /// </summary>
        public static string CreateVenue => "[dbo].[CreateVenue]";
    }
}