namespace SuperTicketApi.Domain.MainContext.DTO.Models
{
    using SuperTicketApi.Domain.MainContext.DTO.Attributes;
    using SuperTicketApi.Domain.Seedwork;

    /// <summary>
    /// The event area.
    /// </summary>
    /// <remarks>
    /// <para><c>SQL:</c>TABLE [dbo].[EventAreas]</para>
    /// </remarks>
    [DbTable("EventAreas")]
    public class EventArea : DomainEntity, IEntity<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventArea"/> class.
        /// </summary>
        public EventArea() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventArea"/> class.
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
        public EventArea(int eventId, string description, int coordX, int coordY, decimal price)
        {
            this.EventId = eventId;
            this.Description = description;
            this.CoordX = coordX;
            this.CoordY = coordY;
            this.Price = price;
        }

        #region Implementation of IEntity<int>
        /// <inheritdoc />
        /// <remarks>
        /// <para><see cref="EventArea"/>Id</para>
        /// <para><c>SQL:</c> int identity primary key.</para>
        /// </remarks>
        [IdColumn(typeof(EventArea))]
        public int Id { get; set; }
        #endregion

        /// <summary>
        /// Gets or sets the event id.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[EventId] <see langword="int"/> NOT NULL.</para>
        /// </remarks>
        [DbColumn("EventId")]
        public int EventId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[Description] nvarchar(200) NOT NULL.</para>
        /// </remarks>
        [DbColumn("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the coordX.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[CoordX] <see langword="int"/> NOT NULL.</para>
        /// </remarks>
        [DbColumn("CoordX")]
        public int CoordX { get; set; }

        /// <summary>
        /// Gets or sets the coordY.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[CoordY] <see langword="int"/> NOT NULL.</para>
        /// </remarks>
        [DbColumn("CoordY")]
        public int CoordY { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[Price] <see langword="decimal"/>(18, 2) NOT NULL.</para>
        /// </remarks>
        [DbColumn("Price")]
        public decimal Price { get; set; }
    }
}
