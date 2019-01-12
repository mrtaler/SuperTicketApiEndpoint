namespace SuperTicketApi.Domain.MainContext.Command.Update
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The update event command.
    /// </summary>
    public class UpdateEventCommand : Event, IRequest<CommandResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateEventCommand"/> class.
        /// </summary>
        public UpdateEventCommand()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateEventCommand"/> class.
        /// </summary>
        /// <param name="isAdminMode">
        /// The is admin mode.
        /// </param>
        public UpdateEventCommand(bool isAdminMode = false)
        {
            this.Command = isAdminMode
                               ? UpdateSpCommandPattern.UpdateEvent
                               : UpdateSpCommandPattern.AdminUpdate.UpdateEventAdm;
        }

        /// <summary>
        /// Gets the command.
        /// </summary>
        public string Command { get; private set; }
    }
}