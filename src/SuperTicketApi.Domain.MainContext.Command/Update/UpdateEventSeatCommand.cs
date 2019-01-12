namespace SuperTicketApi.Domain.MainContext.Command.Update
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The update event seat command.
    /// </summary>
    public class UpdateEventSeatCommand : EventSeat, IRequest<CommandResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateEventSeatCommand"/> class.
        /// </summary>
        public UpdateEventSeatCommand()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateEventSeatCommand"/> class.
        /// </summary>
        /// <param name="isAdminMode">
        /// The is admin mode.
        /// </param>
        public UpdateEventSeatCommand(bool isAdminMode = false)
        {
            this.Command = isAdminMode
                               ? UpdateSpCommandPattern.UpdateEventSeat
                               : UpdateSpCommandPattern.AdminUpdate.UpdateEventSeatAdm;
        }

        /// <summary>
        /// Gets the command.
        /// </summary>
        public string Command { get; private set; }
    }
}