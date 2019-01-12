namespace SuperTicketApi.Domain.MainContext.Command.CreateCommands
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Attributes;

    /// <summary>
    /// The create seat command.
    /// </summary>
    public class CreateSeatCommand : IRequest<CommandResponse>
    {
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

        /// <summary>
        /// The command.
        /// </summary>
        public string Command => CreateSpCommandPattern.CreateSeat;
    }
}