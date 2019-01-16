namespace SuperTicketApi.ApiEndpoint.ViewModel.Venue
{
    /// <summary>
    /// The venue view model.
    /// </summary>
    public class UpdateVenueViewModel : ApiViewModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

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