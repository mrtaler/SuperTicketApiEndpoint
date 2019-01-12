namespace SuperTicketApi.Domain.MainContext.DTO.Models
{
    using SuperTicketApi.Domain.MainContext.DTO.Attributes;
    using SuperTicketApi.Domain.Seedwork;

    /// <summary>
    /// The event seat.
    /// </summary>
    /// <remarks>
    /// <para><c>SQL:</c>TABLE [dbo].[EventSeats]</para>
    /// </remarks>
    [DbTable("EventSeats")]
    public class EventSeat : DomainEntity, IEntity<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventSeat"/> class.
        /// </summary>
        public EventSeat() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventSeat"/> class.
        /// </summary>
        /// <param name="state">
        /// The state.
        /// </param>
        /// <param name="number">
        /// The number.
        /// </param>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="eventAreaId">
        /// The event areas id.
        /// </param>
        public EventSeat(int state, int number, int row, int eventAreaId)
        {
            this.State = state;
            this.Number = number;
            this.Row = row;
            this.EventAreaId = eventAreaId;
        }

        #region Implementation of IEntity<int>

        /// <inheritdoc />
        /// <remarks>
        /// <para><see cref="EventSeat"/>Id</para>
        /// <para><c>SQL:</c> int identity primary key.</para>
        /// </remarks>
        [IdColumn(typeof(EventSeat))]
        public int Id { get; set; }
        #endregion

        /// <summary>
        /// Gets or sets the event areas id.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[EventAreaId] <see langword="int"/> NOT NULL,.</para>
        /// </remarks>
        [DbColumn("EventAreaId")]
        public int EventAreaId { get; set; }

        /// <summary>
        /// Gets or sets the row.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[Row] <see langword="int"/> NOT NULL.</para>
        /// </remarks>
        [DbColumn("Row")]
        public int Row { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[Number] <see langword="int"/> NOT NULL.</para>
        /// </remarks>
        [DbColumn("Number")]
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[State] <see langword="int"/> NOT NULL.</para>
        /// </remarks>
        [DbColumn("State")]
        public int State { get; set; }
    }
}
