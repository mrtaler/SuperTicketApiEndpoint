namespace SuperTicketApi.Domain.MainContext.DTO.Models
{
    using SuperTicketApi.Domain.MainContext.DTO.Attributes;
    using SuperTicketApi.Domain.Seedwork;

    /// <summary>
    /// The layout.
    /// </summary>
    /// <remarks>
    /// <para><c>SQL:</c>TABLE [dbo].[Layouts]</para>
    /// </remarks>
    [DbTable("Layouts")]
    public class Layout : DomainEntity, IEntity<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Layout"/> class.
        /// </summary>
        public Layout()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Layout"/> class.
        /// </summary>
        /// <param name="venueId">
        /// The venue id.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        public Layout(int venueId, string description)
        {
            this.VenueId = venueId;
            this.Description = description;
        }

        #region Implementation of IEntity<int>
        /// <inheritdoc />
        /// <remarks>
        /// <para><see cref="Layout"/>Id</para>
        /// <para><c>SQL:</c> int identity primary key.</para>
        /// </remarks>
        [IdColumn(typeof(Layout))]
        public int Id { get; set; }
        #endregion

        /// <summary>
        /// Gets or sets the venue id.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[VenueId] <see langword="int"/> NOT NULL.</para>
        /// </remarks>
        [DbColumn("VenueId")]
        public int VenueId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[Description] nvarchar(120) NOT NULL.</para>
        /// </remarks>
        [DbColumn("Description")]
        public string Description { get; set; }
    }
}
