namespace SuperTicketApi.Domain.MainContext.Command.CreateCommands
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    public class UpdateEventSeatCommand : EventSeat, IRequest<DalCommandResponse>
    {
        public UpdateEventSeatCommand(bool isAdminMode = false)
        {
            this.Command = isAdminMode
                               ? UpdateSpCommandPattern.UpdateEventSeat
                               : UpdateSpCommandPattern.AdminUpdate.UpdateEventSeatAdm;
        }

        public string Command { get; private set; }
    }
}