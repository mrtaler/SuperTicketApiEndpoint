namespace SuperTicketApi.Domain.MainContext.Command.Update
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The update event area command.
    /// </summary>
    public class UpdateEventAreaCommand : EventArea, IRequest<CommandResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateEventAreaCommand"/> class.
        /// </summary>
        public UpdateEventAreaCommand()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateEventAreaCommand"/> class.
        /// </summary>
        /// <param name="isAdminMode">
        /// The is admin mode.
        /// </param>
        public UpdateEventAreaCommand(bool isAdminMode = false)
        {
            this.Command = isAdminMode
                               ? UpdateSpCommandPattern.UpdateEventArea
                               : UpdateSpCommandPattern.AdminUpdate.UpdateEventAreaAdm;
        }

        /// <summary>
        /// Gets the command.
        /// </summary>
        public string Command { get; private set; }
    }
}