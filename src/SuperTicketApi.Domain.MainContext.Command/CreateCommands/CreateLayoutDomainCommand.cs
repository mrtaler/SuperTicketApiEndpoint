namespace SuperTicketApi.Domain.MainContext.Command.CreateCommands
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Attributes;

    /// <summary>
    /// The create layout command.
    /// </summary>
    public class CreateLayoutDomainCommand : IRequest<CommandResponse>, IDomainCommand
    {
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

        /// <summary>
        /// The command.
        /// </summary>
        public string Command => CreateSpCommandPattern.CreateLayout;
    }
}