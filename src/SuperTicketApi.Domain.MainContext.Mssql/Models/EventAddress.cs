namespace SuperTicketApi.Domain.MainContext.Mssql.Models
{
    using SuperTicketApi.Domain.MainContext.Mssql.Attributes;
    using SuperTicketApi.Domain.Seedwork;

    /// <summary>
    /// The event address. TABLE[dbo].[EventAddress]
    /// </summary>
    [DbTable("EventAddress")]
    public class EventAddress : Entity, IEntity<int>
    {
        /// <summary>
        /// Gets or sets the id.  [EventAddresId] INT NOT NULL PRIMARY KEY, 
        /// </summary>
        
        [DbColumn("EventAddresId")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the street.  [Street] NVARCHAR(50) NULL, 
        /// </summary>
        [DbColumn("Street")]
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the house.  [House] NVARCHAR(10) NULL, 
        /// </summary>
        [DbColumn("House")]
        public string House { get; set; }

        /// <summary>
        /// Gets or sets the description.  [Description] NVARCHAR(500) NULL
        /// </summary>
        [DbColumn("Description")]
        public string Description { get; set; }
    }
}
