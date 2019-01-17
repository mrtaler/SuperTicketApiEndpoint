namespace SuperTicketApi.Application.BoundedContext.DTO.Dto
{
    /// <summary>
    /// The event area.
    /// </summary>
    public class EventAreaDto : IBusinessDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventAreaDto"/> class.
        /// </summary>
        public EventAreaDto()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventAreaDto"/> class. 
        /// </summary>
        /// <param name="eventId">
        /// The event id.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        /// <param name="coordX">
        /// The coordX.
        /// </param>
        /// <param name="coordY">
        /// The coordY.
        /// </param>
        /// <param name="price">
        /// The price.
        /// </param>
        public EventAreaDto(int eventId, string description, int coordX, int coordY, decimal price)
        {
            this.EventId = eventId;
            this.Description = description;
            this.CoordX = coordX;
            this.CoordY = coordY;
            this.Price = price;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the event id.
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the coordX.
        /// </summary>
        public int CoordX { get; set; }

        /// <summary>
        /// Gets or sets the coordY.
        /// </summary>
        public int CoordY { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public decimal Price { get; set; }
    }
}
