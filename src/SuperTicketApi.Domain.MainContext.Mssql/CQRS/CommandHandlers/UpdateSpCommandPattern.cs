namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.CommandHandlers
{
    /// <summary>
    /// The update store procedure command pattern.
    /// </summary>
    public static class UpdateSpCommandPattern
    {
        /// <summary>
        /// The update area.
        /// </summary>
        public static string UpdateArea => "[dbo].[UpdateArea]";

        /// <summary>
        /// The update event.
        /// </summary>
        public static string UpdateEvent => "[dbo].[UpdateEvent]";

        /// <summary>
        /// The update event area.
        /// </summary>
        public static string UpdateEventArea => "[dbo].[UpdateEventArea]";

        /// <summary>
        /// The update event seat.
        /// </summary>
        public static string UpdateEventSeat => "[dbo].[UpdateEventSeat]";

        /// <summary>
        /// The update layout.
        /// </summary>
        public static string UpdateLayout => "[dbo].[UpdateLayout]";

        /// <summary>
        /// The update seat.
        /// </summary>
        public static string UpdateSeat => "[dbo].[UpdateSeat]";

        /// <summary>
        /// The update venue.
        /// </summary>
        public static string UpdateVenue => "[dbo].[UpdateVenue]";

        /// <summary>
        /// The admin update pattern.
        /// </summary>
        public static class AdminUpdate
        {
            /// <summary>
            /// The update area.
            /// </summary>
            public static string UpdateAreaAdm => "[adm].[UpdateArea]";

            /// <summary>
            /// The update event.
            /// </summary>
            public static string UpdateEventAdm => "[adm].[UpdateEvent]";

            /// <summary>
            /// The update event area.
            /// </summary>
            public static string UpdateEventAreaAdm => "[adm].[UpdateEventArea]";

            /// <summary>
            /// The update event seat.
            /// </summary>
            public static string UpdateEventSeatAdm => "[adm].[UpdateEventSeat]";

            /// <summary>
            /// The update layout.
            /// </summary>
            public static string UpdateLayoutAdm => "[adm].[UpdateLayout]";

            /// <summary>
            /// The update seat.
            /// </summary>
            public static string UpdateSeatAdm => "[adm].[UpdateSeat]";
        }
    }
}