namespace SuperTicketApi.ApiEndpoint.ViewModel.EventSeat
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="SuperTicketApi.ApiEndpoint.ViewModel.ApiViewModel" />
    public class EventSeatViewModel :ApiViewModel
    {
        /// <summary>
        /// Gets or sets the event areas identifier.
        /// </summary>
        /// <value>
        /// The event areas identifier.
        /// </value>
        public int EventAreasId { get; set; }
        /// <summary>
        /// Gets or sets the row.
        /// </summary>
        /// <value>
        /// The row.
        /// </value>
        public int Row { get; set; }
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        public int Number { get; set; }
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public int State { get; set; }
    }

 /*
   Area
 EventArea
 Event
 EventSeat
 Layout
 Seat
 Venue
 */
}
