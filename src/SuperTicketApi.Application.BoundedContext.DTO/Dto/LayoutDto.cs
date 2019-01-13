namespace SuperTicketApi.Application.BoundedContext.DTO.Dto
{
    /// <summary>
    /// The layout.
    /// </summary>
    public class LayoutDto : IBusinessDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutDto"/> class.
        /// </summary>
        public LayoutDto()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutDto"/> class. 
        /// </summary>
        /// <param name="venueId">
        /// The venue id.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        public LayoutDto(int venueId, string description)
        {
            this.VenueId = venueId;
            this.Description = description;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the venue id.
        /// </summary>
        public int VenueId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }
    }
}
