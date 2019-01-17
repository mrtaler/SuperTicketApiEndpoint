namespace SuperTicketApi.ApiEndpoint.ViewModel.Seat
{
    public class UpdateSeatViewModel : ApiViewModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

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