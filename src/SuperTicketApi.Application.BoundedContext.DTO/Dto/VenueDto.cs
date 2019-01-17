namespace SuperTicketApi.Application.BoundedContext.DTO.Dto
{
    /// <summary>
    /// The venue.
    /// </summary>
    public class VenueDto : IBusinessDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VenueDto"/> class. 
        /// </summary>
        public VenueDto()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VenueDto"/> class. 
        /// </summary>
        /// <param name="phone">
        /// The phone.
        /// </param>
        /// <param name="address">
        /// The address.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        public VenueDto(string phone, string address, string description)
        {
            this.Phone = phone;
            this.Address = address;
            this.Description = description;
        }

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
