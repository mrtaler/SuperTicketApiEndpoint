namespace SuperTicketApi.ApiEndpoint.ViewModel.Seat
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="SuperTicketApi.ApiEndpoint.ViewModel.ApiViewModel" />
    public class CreateSeatViewModel : ApiViewModel
    {
        /// <summary>
        /// Gets or sets the area identifier.
        /// </summary>
        /// <value>
        /// The area identifier.
        /// </value>
        public int AreaId { get; set; }

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
    }
}
