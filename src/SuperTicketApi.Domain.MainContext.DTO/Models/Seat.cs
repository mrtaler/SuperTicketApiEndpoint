namespace SuperTicketApi.Domain.MainContext.DTO.Models
{
    using SuperTicketApi.Domain.MainContext.DTO.Attributes;
    using SuperTicketApi.Domain.Seedwork;

    /// <summary>
    /// The seat.
    /// </summary>
    /// <remarks>
    /// <para><c>SQL:</c>TABLE [dbo].[Seats]</para>
    /// </remarks>
    [DbTable("Seats")]
    public class Seat : DomainEntity, IEntity<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Seat"/> class.
        /// </summary>
        public Seat()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Seat"/> class.
        /// </summary>
        /// <param name="areaId">
        /// The area id.
        /// </param>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="number">
        /// The number.
        /// </param>
        public Seat(int areaId, int row, int number)
        {
            this.AreaId = areaId;
            this.Row = row;
            this.Number = number;
        }

        #region Implementation of IEntity<int>
        /// <inheritdoc />
        /// <remarks>
        /// <para><see cref="Seat"/>Id</para>
        /// <para><c>SQL:</c> int identity primary key.</para>
        /// </remarks>
        [IdColumn(typeof(Seat))]
        public int Id { get; set; }
        #endregion

        /// <summary>
        /// Gets or sets the area id.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[AreaId] <see langword="int"/> NOT NULL</para>
        /// </remarks>
        [DbColumn("AreaId")]
        public int AreaId { get; set; }

        /// <summary>
        /// Gets or sets the row.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[Row] <see langword="int"/> NOT NULL</para>
        /// </remarks>
        [DbColumn("Row")]
        public int Row { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[Number] <see langword="int"/> NOT NULL</para>
        /// </remarks>
        [DbColumn("Number")]
        public int Number { get; set; }
    }
}
