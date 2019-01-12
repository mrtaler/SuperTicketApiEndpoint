namespace SuperTicketApi.Domain.MainContext.Command.Update
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The update area command.
    /// </summary>
    public class UpdateAreaCommand : Area, IRequest<CommandResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateAreaCommand"/> class.
        /// </summary>
        public UpdateAreaCommand()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateAreaCommand"/> class.
        /// </summary>
        /// <param name="isAdminMode">
        /// The is admin mode.
        /// </param>
        public UpdateAreaCommand(bool isAdminMode = false)
        {
            this.Command = isAdminMode
                ? UpdateSpCommandPattern.UpdateArea
                : UpdateSpCommandPattern.AdminUpdate.UpdateAreaAdm;
        }

        /// <summary>
        /// Gets the command.
        /// </summary>
        public string Command { get; private set; }
    }
}