using MediatR;
using SuperTicketApi.Domain.MainContext.DTO.Models;

namespace SuperTicketApi.Domain.MainContext.Command.CreateCommands
{
    public class UpdateAreaCommand : Area, IRequest<DalCommandResponse>
    {
        public UpdateAreaCommand() { }


        public UpdateAreaCommand(bool isAdminMode = false)
        {
            Command = isAdminMode
                ? UpdateSpCommandPattern.UpdateArea
                : UpdateSpCommandPattern.AdminUpdate.UpdateAreaAdm;
        }
        public string Command { get; private set; }
    }

    public class UpdateEventAreaCommand : EventArea, IRequest<DalCommandResponse>
    {
        public UpdateEventAreaCommand(bool isAdminMode = false)
        {
            Command = isAdminMode
                ? UpdateSpCommandPattern.UpdateEventArea
                : UpdateSpCommandPattern.AdminUpdate.UpdateEventAreaAdm;
        }
        public string Command { get; private set; }
    }

    public class UpdateEventCommand : Event, IRequest<DalCommandResponse>
    {
        public UpdateEventCommand(bool isAdminMode = false)
        {
            Command = isAdminMode
                ? UpdateSpCommandPattern.UpdateEvent
                : UpdateSpCommandPattern.AdminUpdate.UpdateEventAdm;
        }
        public string Command { get; private set; }
    }
    public class UpdateEventSeatCommand : EventSeat, IRequest<DalCommandResponse>
    {
        public UpdateEventSeatCommand(bool isAdminMode = false)
        {
            Command = isAdminMode
                ? UpdateSpCommandPattern.UpdateEventSeat
                : UpdateSpCommandPattern.AdminUpdate.UpdateEventSeatAdm;
        }
        public string Command { get; private set; }
    }
    public class UpdateLayoutCommand : Layout, IRequest<DalCommandResponse>
    {
        public UpdateLayoutCommand(bool isAdminMode = false)
        {
            Command = isAdminMode
                ? UpdateSpCommandPattern.UpdateLayout
                : UpdateSpCommandPattern.AdminUpdate.UpdateLayoutAdm;
        }
        public string Command { get; private set; }
    }
    public class UpdateSeatCommand : Seat, IRequest<DalCommandResponse>
    {
        public UpdateSeatCommand(bool isAdminMode = false)
        {
            Command = isAdminMode
                ? UpdateSpCommandPattern.UpdateSeat
                : UpdateSpCommandPattern.AdminUpdate.UpdateSeatAdm;
        }
        public string Command { get; private set; }
    }
    public class UpdateVenueCommand : Venue, IRequest<DalCommandResponse>
    {
        public UpdateVenueCommand(bool isAdminMode = false)
        {
            Command = UpdateSpCommandPattern.UpdateVenue;
        }
        public string Command { get; private set; }
    }

}