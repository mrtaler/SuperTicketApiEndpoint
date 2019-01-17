namespace SuperTicketApi.Domain.MainContext.Command.Update
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The update event command.
    /// </summary>
    public class UpdateEventDomainCommand : Event, IRequest<DomainCommandResponse>, IDomainCommand
    {
        /// <summary>
        /// The is admin mode.
        /// </summary>
        private bool isAdminMode;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateEventDomainCommand"/> class.
        /// </summary>
        public UpdateEventDomainCommand()
        {
            this.isAdminMode = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateEventDomainCommand"/> class.
        /// </summary>
        /// <param name="isAdminMode">
        /// The is admin mode.
        /// </param>
        public UpdateEventDomainCommand(bool isAdminMode = false)
        {
            SwitchToAdminMode(isAdminMode);
        }

        public void SwitchToAdminMode(bool isAdminMode = true)
        {
            this.isAdminMode = isAdminMode;
        }
        
        /// <summary>
        /// Gets the command.
        /// </summary>
        public new string Command => !this.isAdminMode
                               ? UpdateSpCommandPattern.UpdateEvent
                               : UpdateSpCommandPattern.AdminUpdate.UpdateEventAdm;
    }
}