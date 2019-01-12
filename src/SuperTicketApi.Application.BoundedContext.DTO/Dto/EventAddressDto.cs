namespace SuperTicketApi.Application.BoundedContext.DTO.Dto
{
    public abstract class BusinesEntity
    {

    }

    /// <summary>
    /// The event address. TABLE[dbo].[EventAddress]
    /// </summary>
    public class EventAddressDto : BusinesEntity
    {
        /// <summary>
        /// Gets or sets the id.  [EventAddresId] INT NOT NULL PRIMARY KEY, 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the street.  [Street] NVARCHAR(50) NULL, 
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the house.  [House] NVARCHAR(10) NULL, 
        /// </summary>
        public string House { get; set; }

        /// <summary>
        /// Gets or sets the description.  [Description] NVARCHAR(500) NULL
        /// </summary>
        public string Description { get; set; }
    }
}
