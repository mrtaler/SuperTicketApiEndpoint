namespace SuperTicketApi.Domain.MainContext.Command.Update
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The update venue command.
    /// </summary>
    public class UpdateVenueDomainCommand : Venue, IRequest<CommandResponse>, IDomainCommand
    {
        /// <summary>
        /// The is admin mode.
        /// </summary>
        private  bool isAdminMode;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateVenueDomainCommand"/> class.
        /// </summary>
        public UpdateVenueDomainCommand()
        {
            this.isAdminMode = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateVenueDomainCommand"/> class.
        /// </summary>
        /// <param name="isAdminMode">
        /// The is admin mode.
        /// </param>
        public UpdateVenueDomainCommand(bool isAdminMode = false)
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
        public new string Command => UpdateSpCommandPattern.UpdateVenue;
    }
}