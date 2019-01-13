namespace SuperTicketApi.Domain.MainContext.Command.Update
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The update event seat command.
    /// </summary>
    public class UpdateEventSeatDomainCommand : EventSeat, IRequest<CommandResponse>, IDomainCommand
    {
        /// <summary>
        /// The is admin mode.
        /// </summary>
        private readonly bool isAdminMode;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateEventSeatDomainCommand"/> class.
        /// </summary>
        public UpdateEventSeatDomainCommand()
        {
            this.isAdminMode = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateEventSeatDomainCommand"/> class.
        /// </summary>
        /// <param name="isAdminMode">
        /// The is admin mode.
        /// </param>
        public UpdateEventSeatDomainCommand(bool isAdminMode = false)
        {
            this.isAdminMode = isAdminMode;
        }

        /// <summary>
        /// Gets the command.
        /// </summary>
        public new string Command => !this.isAdminMode
                               ? UpdateSpCommandPattern.UpdateEventSeat
                               : UpdateSpCommandPattern.AdminUpdate.UpdateEventSeatAdm;
    }
}