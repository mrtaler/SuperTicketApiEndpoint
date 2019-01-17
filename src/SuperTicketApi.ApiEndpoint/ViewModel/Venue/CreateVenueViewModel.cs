namespace SuperTicketApi.ApiEndpoint.ViewModel.Venue
{
    /// <summary>
    /// The venue view model.
    /// </summary>
    public class CreateVenueViewModel : ApiViewModel
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        public string Phone { get; set; }
    }
}
