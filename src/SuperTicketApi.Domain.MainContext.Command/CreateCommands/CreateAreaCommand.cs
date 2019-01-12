using MediatR;

using SuperTicketApi.Domain.MainContext.DTO.Attributes;

namespace SuperTicketApi.Domain.MainContext.Command.CreateCommands
{
    public class CreateAreaCommand : IRequest<DalCommandResponse>
    {
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
        public string Command => CreateSpCommandPattern.CreateArea;
    }
}