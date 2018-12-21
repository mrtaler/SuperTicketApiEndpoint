namespace SuperTicketApi.Application.BoundedContext.DTO
{
    public class TechnicalLevelDto
    {
        /// <summary>
        /// Gets or sets Tl Id
        /// </summary>
        public int TechnicalLevelId { get; set; }

        /// <summary>
        /// Gets or sets Name of TechLevel
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Description of Tech Level
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets Start money fo current TechLevel
        /// </summary>
        public decimal StartMoney { get; set; }
    }
}
