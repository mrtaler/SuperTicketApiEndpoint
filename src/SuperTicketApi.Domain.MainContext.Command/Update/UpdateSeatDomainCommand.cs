namespace SuperTicketApi.Domain.MainContext.Command.Update
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The update seat command.
    /// </summary>
    public class UpdateSeatDomainCommand : Seat, IRequest<CommandResponse>, IDomainCommand
    {
        /// <summary>
        /// The is admin mode.
        /// </summary>
        private bool isAdminMode;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSeatDomainCommand"/> class.
        /// </summary>
        public UpdateSeatDomainCommand()
        {
            this.isAdminMode = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSeatDomainCommand"/> class.
        /// </summary>
        /// <param name="isAdminMode">
        /// The is admin mode.
        /// </param>
        public UpdateSeatDomainCommand(bool isAdminMode = false)
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
                               ? UpdateSpCommandPattern.UpdateSeat
                               : UpdateSpCommandPattern.AdminUpdate.UpdateSeatAdm;
    }
}