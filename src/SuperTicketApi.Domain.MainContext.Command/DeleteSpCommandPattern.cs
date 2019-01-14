namespace SuperTicketApi.Domain.MainContext.Command
{
    /// <summary>
    /// The delete sp command pattern.
    /// </summary>
    public static class DeleteSpCommandPattern
    {
        /// <summary>
        /// The delete area Command
        /// </summary>
        public static string DeleteArea => "[dbo].[DeleteByIdArea]";

        /// <summary>
        /// The delete event Command
        /// </summary>
        public static string DeleteEvent => "[dbo].[DeleteByIdEvent]";

        /// <summary>
        /// The delete event area Command
        /// </summary>
        public static string DeleteEventArea => "[dbo].[DeleteByIdEventArea]";

        /// <summary>
        /// The delete event seat Command
        /// </summary>
        public static string DeleteEventSeat => "[dbo].[CreateEventSeat]";

        /// <summary>
        /// The delete layout Command
        /// </summary>
        public static string DeleteLayout => "[dbo].[DeleteByIdLayout]";

        /// <summary>
        /// The delete seat Command
        /// </summary>
        public static string DeleteSeat => "[dbo].[DeleteByIdSeat]";

        /// <summary>
        /// The delete venue Command
        /// </summary>
        public static string DeleteVenue => "[dbo].[DeleteByIdVenue]";
    }
}