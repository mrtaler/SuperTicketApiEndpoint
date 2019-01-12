namespace SuperTicketApi.Domain.MainContext.Command.CreateCommands
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Attributes;

    public class CreateEventAreaCommand : IRequest<DalCommandResponse>
    {
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
        public string Command => CreateSpCommandPattern.CreateEventArea;
    }
}