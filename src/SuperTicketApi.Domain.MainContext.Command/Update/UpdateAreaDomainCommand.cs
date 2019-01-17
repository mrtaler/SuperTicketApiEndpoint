namespace SuperTicketApi.Domain.MainContext.Command.Update
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The update area command.
    /// </summary>
    public class UpdateAreaDomainCommand : Area, IRequest<DomainCommandResponse>, IDomainCommand
    {
        /// <summary>
        /// The is admin mode.
        /// </summary>
        private bool isAdminMode;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateAreaDomainCommand"/> class.
        /// </summary>
        public UpdateAreaDomainCommand()
        {
            this.isAdminMode = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateAreaDomainCommand"/> class.
        /// </summary>
        /// <param name="isAdminMode">
        /// The is admin mode.
        /// </param>
        public UpdateAreaDomainCommand(bool isAdminMode = false)
        {
            SwitchToAdminMode(isAdminMode);
        }

        public void SwitchToAdminMode(bool isAdminMode = true)
        {
            this.isAdminMode = isAdminMode;
        }

        /// <summary>
        /// Gets the commands
        /// </summary>
        public new string Command => !this.isAdminMode
                ? UpdateSpCommandPattern.UpdateArea
                : UpdateSpCommandPattern.AdminUpdate.UpdateAreaAdm;
    }
}