namespace SuperTicketApi.ApiEndpoint.ViewModel.EventArea
{
    /// <summary>
    /// The update event area view model.
    /// </summary>
    public class UpdateEventAreaViewModel : ApiViewModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// Gets or sets the event identifier.
        /// </summary>
        /// <value>
        /// The event identifier.
        /// </value>
        public int EventId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the coord x.
        /// </summary>
        /// <value>
        /// The coord x.
        /// </value>
        public int CoordX { get; set; }

        /// <summary>
        /// Gets or sets the coord y.
        /// </summary>
        /// <value>
        /// The coord y.
        /// </value>
        public int CoordY { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal Price { get; set; }
    }
}