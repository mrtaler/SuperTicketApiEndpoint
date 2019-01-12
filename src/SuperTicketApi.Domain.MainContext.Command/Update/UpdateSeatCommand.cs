namespace SuperTicketApi.Domain.MainContext.Command.Update
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The update seat command.
    /// </summary>
    public class UpdateSeatCommand : Seat, IRequest<CommandResponse>, IDomainCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSeatCommand"/> class.
        /// </summary>
        public UpdateSeatCommand()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSeatCommand"/> class.
        /// </summary>
        /// <param name="isAdminMode">
        /// The is admin mode.
        /// </param>
        public UpdateSeatCommand(bool isAdminMode = false)
        {
            this.Command = isAdminMode
                               ? UpdateSpCommandPattern.UpdateSeat
                               : UpdateSpCommandPattern.AdminUpdate.UpdateSeatAdm;
        }

        /// <summary>
        /// Gets the command.
        /// </summary>
        public string Command { get; private set; }
    }
}