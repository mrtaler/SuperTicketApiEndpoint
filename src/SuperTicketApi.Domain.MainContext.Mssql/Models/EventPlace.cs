namespace SuperTicketApi.Domain.MainContext.Mssql.Models
{
    using SuperTicketApi.Domain.MainContext.Mssql.Attributes;
    using SuperTicketApi.Domain.Seedwork;

    /// <summary>
    /// The event place. TABLE [dbo].[EventPlace]
    /// </summary>
    [DbTable("EventPlace")]
    public class EventPlace : Entity, IEntity<int>
    {
        /// <summary>
        /// Gets or sets the id. [EventPlaceId] INT NOT NULL PRIMARY KEY, 
        /// </summary>
        [DbColumn("EventPlaceId")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the places <c>Admin</c>. [PlacesAdmin] NVARCHAR(50) NOT NULL, 
        /// </summary>
        [DbColumn("PlacesAdmin")]
        public string PlacesAdmin { get; set; }

        /// <summary>
        /// Gets or sets the Admin telephone.  [AdminTelephone] NVARCHAR(50) NOT NULL, 
        /// </summary>
        [DbColumn("AdminTelephone")]
        public string AdminTelephone { get; set; }

        /// <summary>
        /// Gets or sets the cost per hour.  [CostPerHour] DECIMAL NOT NULL, 
        /// </summary>
        [DbColumn("CostPerHour")]
        public decimal CostPerHour { get; set; }
    }
}