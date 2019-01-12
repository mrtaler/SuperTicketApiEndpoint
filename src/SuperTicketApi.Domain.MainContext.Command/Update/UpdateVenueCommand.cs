namespace SuperTicketApi.Domain.MainContext.Command.Update
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The update venue command.
    /// </summary>
    public class UpdateVenueCommand : Venue, IRequest<CommandResponse>, IDomainCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateVenueCommand"/> class.
        /// </summary>
        public UpdateVenueCommand()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateVenueCommand"/> class.
        /// </summary>
        /// <param name="isAdminMode">
        /// The is admin mode.
        /// </param>
        public UpdateVenueCommand(bool isAdminMode = false)
        {
            this.Command = UpdateSpCommandPattern.UpdateVenue;
        }

        /// <summary>
        /// Gets the command.
        /// </summary>
        public string Command { get; private set; }
    }
}