namespace SuperTicketApi.Domain.MainContext.Mssql.Models
{
    using SuperTicketApi.Domain.Seedwork;

    /// <summary>
    /// The event place. TABLE [dbo].[EventPlace]
    /// </summary>
    public class EventPlace : Entity, IEntity<int>
    {
        /// <summary>
        /// Gets or sets the id. [EventPlaceId] INT NOT NULL PRIMARY KEY, 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the places <c>Admin</c>. [PlacesAdmin] NVARCHAR(50) NOT NULL, 
        /// </summary>
        public string PlacesAdmin { get; set; }

        /// <summary>
        /// Gets or sets the Admin telephone.  [AdminTelephone] NVARCHAR(50) NOT NULL, 
        /// </summary>
        public string AdminTelephone { get; set; }

        /// <summary>
        /// Gets or sets the cost per hour.  [CostPerHour] DECIMAL NOT NULL, 
        /// </summary>
        public decimal CostPerHour { get; set; }
    }
}