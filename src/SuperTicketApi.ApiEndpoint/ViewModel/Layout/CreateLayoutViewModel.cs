namespace SuperTicketApi.ApiEndpoint.ViewModel.Layout
{
    /// <summary>
    /// The create layout view model.
    /// </summary>
    public class CreateLayoutViewModel : ApiViewModel
    {
        /// <summary>
        /// Gets or sets the venue identifier.
        /// </summary>
        /// <value>
        /// The venue identifier.
        /// </value>
        public int VenueId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
    }
}
