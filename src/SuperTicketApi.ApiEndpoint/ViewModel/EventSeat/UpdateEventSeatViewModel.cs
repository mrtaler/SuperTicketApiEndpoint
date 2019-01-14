namespace SuperTicketApi.ApiEndpoint.ViewModel.EventSeat
{
    /// <summary>
    /// The update event seat view model.
    /// </summary>
    public class UpdateEventSeatViewModel : ApiViewModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the event areas identifier.
        /// </summary>
        /// <value>
        /// The event areas identifier.
        /// </value>
        public int EventAreaId { get; set; }

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
}