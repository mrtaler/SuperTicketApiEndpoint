namespace SuperTicketApi.Domain.MainContext.Command.Update
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The update layout command.
    /// </summary>
    public class UpdateLayoutDomainCommand : Layout, IRequest<CommandResponse>, IDomainCommand
    {
        /// <summary>
        /// The is admin mode.
        /// </summary>
        private readonly bool isAdminMode;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateLayoutDomainCommand"/> class.
        /// </summary>
        public UpdateLayoutDomainCommand()
        {
            this.isAdminMode = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateLayoutDomainCommand"/> class.
        /// </summary>
        /// <param name="isAdminMode">
        /// The is admin mode.
        /// </param>
        public UpdateLayoutDomainCommand(bool isAdminMode = false)
        {
            this.isAdminMode = isAdminMode;
        }

        /// <summary>
        /// Gets the command.
        /// </summary>
        public new string Command => !this.isAdminMode
                               ? UpdateSpCommandPattern.UpdateLayout
                               : UpdateSpCommandPattern.AdminUpdate.UpdateLayoutAdm;
    }
}