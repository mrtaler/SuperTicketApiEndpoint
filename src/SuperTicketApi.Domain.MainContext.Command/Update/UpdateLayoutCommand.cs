namespace SuperTicketApi.Domain.MainContext.Command.Update
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The update layout command.
    /// </summary>
    public class UpdateLayoutCommand : Layout, IRequest<DalCommandResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateLayoutCommand"/> class.
        /// </summary>
        public UpdateLayoutCommand()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateLayoutCommand"/> class.
        /// </summary>
        /// <param name="isAdminMode">
        /// The is admin mode.
        /// </param>
        public UpdateLayoutCommand(bool isAdminMode = false)
        {
            this.Command = isAdminMode
                               ? UpdateSpCommandPattern.UpdateLayout
                               : UpdateSpCommandPattern.AdminUpdate.UpdateLayoutAdm;
        }

        /// <summary>
        /// Gets the command.
        /// </summary>
        public string Command { get; private set; }
    }
}