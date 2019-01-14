namespace SuperTicketApi.Application.BoundedContext.DTO.Dto
{
    /// <summary>
    /// The area.
    /// </summary>
    public class AreaDto : IBusinessDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AreaDto"/> class. 
        /// </summary>
        public AreaDto()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AreaDto"/> class. 
        /// </summary>
        /// <param name="coordY">
        /// The coordY.
        /// </param>
        /// <param name="coordX">
        /// The coordX.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        /// <param name="layoutId">
        /// The layout id.
        /// </param>
        public AreaDto(int coordY, int coordX, string description, int layoutId)
        {
            this.CoordY = coordY;
            this.CoordX = coordX;
            this.Description = description;
            this.LayoutId = layoutId;
        }

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
        /// Gets or sets the CoordX.
        /// </summary>
        public int CoordX { get; set; }

        /// <summary>
        /// Gets or sets the CoordY.
        /// </summary>
        public int CoordY { get; set; }
    }
}
