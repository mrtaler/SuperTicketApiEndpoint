namespace SuperTicketApi.Application.BoundedContext.DTO.Dto
{
    /// <summary>
    /// The seat.
    /// </summary>
    public class SeatDto : IBusinessDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SeatDto"/> class. 
        /// </summary>
        public SeatDto()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SeatDto"/> class. 
        /// </summary>
        /// <param name="areaId">
        /// The area id.
        /// </param>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="number">
        /// The number.
        /// </param>
        public SeatDto(int areaId, int row, int number)
        {
            this.AreaId = areaId;
            this.Row = row;
            this.Number = number;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the area id.
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// Gets or sets the row.
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        public int Number { get; set; }
    }
}
