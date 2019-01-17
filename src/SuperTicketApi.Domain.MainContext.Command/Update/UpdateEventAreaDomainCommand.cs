namespace SuperTicketApi.Domain.MainContext.Command.Update
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The update event area command.
    /// </summary>
    public class UpdateEventAreaDomainCommand : EventArea, IRequest<DomainCommandResponse>, IDomainCommand
    {
        /// <summary>
        /// The is admin mode.
        /// </summary>
        private bool isAdminMode;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateEventAreaDomainCommand"/> class.
        /// </summary>
        public UpdateEventAreaDomainCommand()
        {
            this.isAdminMode = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateEventAreaDomainCommand"/> class.
        /// </summary>
        /// <param name="isAdminMode">
        /// The is admin mode.
        /// </param>
        public UpdateEventAreaDomainCommand(bool isAdminMode = false)
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
                               ? UpdateSpCommandPattern.UpdateEventArea
                               : UpdateSpCommandPattern.AdminUpdate.UpdateEventAreaAdm;
    }
}