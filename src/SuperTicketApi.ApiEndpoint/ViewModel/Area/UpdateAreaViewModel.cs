namespace SuperTicketApi.ApiEndpoint.ViewModel.Area
{
    using System.Collections.Generic;

    using SuperTicketApi.ApiEndpoint.ViewModel.Seat;

    /// <summary>
    /// The area view model.
    /// </summary>
    public class UpdateAreaViewModel : ApiViewModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the layout id.
        /// </summary>
        public int LayoutId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the coord x.
        /// </summary>
        public int CoordX { get; set; }

        /// <summary>
        /// Gets or sets the coord y.
        /// </summary>
        public int CoordY { get; set; }
    }
}
