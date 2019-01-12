namespace SuperTicketApi.Domain.MainContext.Command.CreateCommands
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    public class UpdateEventCommand : Event, IRequest<DalCommandResponse>
    {
        public UpdateEventCommand(bool isAdminMode = false)
        {
            this.Command = isAdminMode
                               ? UpdateSpCommandPattern.UpdateEvent
                               : UpdateSpCommandPattern.AdminUpdate.UpdateEventAdm;
        }

        public string Command { get; private set; }
    }
}