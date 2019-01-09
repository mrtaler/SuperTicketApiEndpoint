using MediatR;
using SuperTicketApi.Domain.MainContext.Command.Delete;
using SuperTicketApi.Domain.MainContext.DTO.Attributes;
using SuperTicketApi.Domain.MainContext.DTO.Models;

namespace SuperTicketApi.Domain.MainContext.Command.CreateCommands
{
    public class DeleteAreaCommand : IRequest<DalCommandResponse>
    {
        public DeleteAreaCommand(int id)
        {
            this.Id = id;
        }
        [IdColumn(typeof(Area))]
        public int Id { get; private set; }
        public string Command => DeleteSpCommandPattern.DeleteArea;
    }
    public class DeleteEventAreaCommand : IRequest<DalCommandResponse>
    {
        public DeleteEventAreaCommand(int id)
        {
            this.Id = id;
        }
        public int Id { get; private set; }
        public string Command => DeleteSpCommandPattern.DeleteEventArea;
    }
    public class DeleteEventCommand : IRequest<DalCommandResponse>
    {
        public DeleteEventCommand(int id)
        {
            this.Id = id;
        }
        public int Id { get; private set; }
        public string Command => DeleteSpCommandPattern.DeleteEvent;
    }
    public class DeleteEventSeatCommand : IRequest<DalCommandResponse>
    {
        public DeleteEventSeatCommand(int id)
        {
            this.Id = id;
        }
        public int Id { get; private set; }
        public string Command => DeleteSpCommandPattern.DeleteEventSeat;
    }
    public class DeleteLayoutCommand : IRequest<DalCommandResponse>
    {
        public DeleteLayoutCommand(int id)
        {
            this.Id = id;
        }
        public int Id { get; private set; }
        public string Command => DeleteSpCommandPattern.DeleteLayout;
    }
    public class DeleteSeatCommand : IRequest<DalCommandResponse>
    {
        public DeleteSeatCommand(int id)
        {
            this.Id = id;
        }
        public int Id { get; private set; }
        public string Command => DeleteSpCommandPattern.DeleteSeat;
    }
    public class DeleteVenueCommand : IRequest<DalCommandResponse>
    {
        public DeleteVenueCommand(int id)
        {
            this.Id = id;
        }
        public int Id { get; private set; }
        public string Command => DeleteSpCommandPattern.DeleteVenue;
    }
}