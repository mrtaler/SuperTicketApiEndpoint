namespace SuperTicketApi.Domain.MainContext.Command.CreateCommands
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Attributes;

    /// <summary>
    /// The create venue command.
    /// </summary>
    public class CreateVenueCommand : IRequest<DalCommandResponse>
    {
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

        /// <summary>
        /// The command.
        /// </summary>
        public string Command => CreateSpCommandPattern.CreateVenue;
    }
}