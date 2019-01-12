namespace SuperTicketApi.Domain.MainContext.Command.CreateCommands
{
    using System;

    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Attributes;

    /// <summary>
    /// The create event command.
    /// </summary>
    public class CreateEventCommand : IRequest<DalCommandResponse>
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[Name] nvarchar(120) NOT NULL.</para>
        /// </remarks>
        [DbColumn("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the banner.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[Banner] nvarchar(max) NOT NULL.</para>
        /// </remarks>
        [DbColumn("Banner")]
        public string Banner { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[Description] nvarchar(max) NOT NULL.</para>
        /// </remarks>
        [DbColumn("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the start at.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[StartAt] DATETIME NOT NULL.</para>
        /// </remarks>
        [DbColumn("StartAt")]
        public DateTime StartAt { get; set; }

        /// <summary>
        /// Gets or sets the run time.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[Runtime] TIME(7) NOT NULL.</para>
        /// </remarks>
        [DbColumn("RunTime")]
        public TimeSpan RunTime { get; set; }

        /// <summary>
        /// Gets or sets the layout id.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[LayoutId] <see langword="int"/> NOT NULL.</para>
        /// </remarks>
        [DbColumn("LayoutId")]
        public int LayoutId { get; set; }

        /// <summary>
        /// The command.
        /// </summary>
        public string Command => CreateSpCommandPattern.CreateEvent;
    }
}