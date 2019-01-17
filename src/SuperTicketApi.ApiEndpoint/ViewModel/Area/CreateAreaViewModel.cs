namespace SuperTicketApi.ApiEndpoint.ViewModel.Area
{
    /// <summary>
    /// The create area view model.
    /// </summary>
    public class CreateAreaViewModel:ApiViewModel
    {
        /// <summary>
        /// Gets or sets the layout identifier.
        /// </summary>
        /// <value>
        /// The layout identifier.
        /// </value>
        public int LayoutId { get; set; }

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
    }
}
