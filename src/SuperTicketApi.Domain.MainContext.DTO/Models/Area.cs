namespace SuperTicketApi.Domain.MainContext.DTO.Models
{
    using SuperTicketApi.Domain.MainContext.DTO.Attributes;
    using SuperTicketApi.Domain.Seedwork;

    /// <summary>
    /// The area.
    /// </summary>
    /// <remarks>
    /// <para><c>SQL:</c>TABLE [dbo].[Areas]</para>
    /// </remarks>
    [DbTable("Areas")]
    public class Area : Entity, IEntity<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Area"/> class.
        /// </summary>
        public Area()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Area"/> class.
        /// </summary>
        /// <param name="coordY">
        /// The coordY.
        /// </param>
        /// <param name="coordX">
        /// The coordX.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        /// <param name="layoutId">
        /// The layout id.
        /// </param>
        public Area(int coordY, int coordX, string description, int layoutId)
        {
            this.CoordY = coordY;
            this.CoordX = coordX;
            this.Description = description;
            this.LayoutId = layoutId;
        }

        #region Implementation of IEntity<int>
        /// <inheritdoc />
        /// <remarks>
        /// <para><see cref="Area"/>Id</para>
        /// <para><c>SQL:</c> int identity primary key.</para>
        /// </remarks>
        [IdColumn(typeof(Area))]
        public int Id { get; set; }
        #endregion

        /// <summary>
        /// Gets or sets the layout id.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[LayoutId] <see langword="int"/> NOT NULL.</para>
        /// </remarks>
        [DbColumn("LayoutId")]
        public int LayoutId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[Description] nvarchar(200) NOT NULL.</para>
        /// </remarks>
        [DbColumn("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the CoordX.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[CoordX] <see langword="int"/> NOT NULL.</para>
        /// </remarks>
        [DbColumn("CoordX")]
        public int CoordX { get; set; }

        /// <summary>
        /// Gets or sets the CoordY.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[CoordY] <see langword="int"/> NOT NULL.</para>
        /// </remarks>
        [DbColumn("CoordY")]
        public int CoordY { get; set; }
    }
}
