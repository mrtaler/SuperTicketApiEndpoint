namespace SuperTicketApi.Domain.MainContext.Command.CreateCommands
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Attributes;

    public class CreateEventSeatCommand : IRequest<DalCommandResponse>

    { /// <summary>
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
        public string Command => CreateSpCommandPattern.CreateEventSeat;
    }
}