namespace SuperTicketApi.Domain.MainContext.Command.CreateCommands
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    public class UpdateVenueCommand : Venue, IRequest<DalCommandResponse>
    {
        public UpdateVenueCommand(bool isAdminMode = false)
        {
            this.Command = UpdateSpCommandPattern.UpdateVenue;
        }

        public string Command { get; private set; }
    }
}