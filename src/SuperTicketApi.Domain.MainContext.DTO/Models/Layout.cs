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
    public class Layout : Entity, IEntity<int>
    {
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
