namespace SuperTicketApi.Domain.MainContext.DTO.Models
{
    using SuperTicketApi.Domain.MainContext.DTO.Attributes;
    using SuperTicketApi.Domain.Seedwork;

    /// <summary>
    /// The venue.
    /// </summary>
    /// <remarks>
    /// <para><c>SQL:</c>[dbo].[Venues]</para>
    /// </remarks>
    [DbTable("Venues")]
    public class Venue : DomainEntity, IEntity<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Venue"/> class.
        /// </summary>
        public Venue()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Venue"/> class.
        /// </summary>
        /// <param name="phone">
        /// The phone.
        /// </param>
        /// <param name="address">
        /// The address.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        public Venue(string phone, string address, string description)
        {
            this.Phone = phone;
            this.Address = address;
            this.Description = description;
        }

        #region Implementation of IEntity<int>

        /// <inheritdoc />
        /// <remarks>
        /// <para><see cref="Venue"/>Id</para>
        /// <para><c>SQL:</c> int identity primary key.</para>
        /// </remarks>
        [IdColumn(typeof(Venue))]
        public int Id { get; set; }
        #endregion

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[Description] nvarchar(120) NOT NULL.</para>
        /// </remarks>
        [DbColumn("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[Address] nvarchar(200) NOT NULL.</para>
        /// </remarks>
        [DbColumn("Address")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[Phone] nvarchar(30).</para>
        /// </remarks>
        [DbColumn("Phone")]
        public string Phone { get; set; }
    }
}
