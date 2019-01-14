namespace SuperTicketApi.Application.BoundedContext.DTO.Dto
{
    /// <summary>
    /// The event seat.
    /// </summary>
    public class EventSeatDto : IBusinessDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventSeatDto"/> class.
        /// </summary>
        public EventSeatDto()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventSeatDto"/> class. 
        /// </summary>
        /// <param name="state">
        /// The state.
        /// </param>
        /// <param name="number">
        /// The number.
        /// </param>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="eventAreaId">
        /// The event areas id.
        /// </param>
        public EventSeatDto(int state, int number, int row, int eventAreaId)
        {
            this.State = state;
            this.Number = number;
            this.Row = row;
            this.EventAreaId = eventAreaId;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the event areas id.
        /// </summary>
        public int EventAreaId { get; set; }

        /// <summary>
        /// Gets or sets the row.
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public int State { get; set; }
    }
}
