namespace SuperTicketApi.Domain.MainContext.Command.CreateCommands
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    public class UpdateEventAreaCommand : EventArea, IRequest<DalCommandResponse>
    {
        public UpdateEventAreaCommand(bool isAdminMode = false)
        {
            this.Command = isAdminMode
                               ? UpdateSpCommandPattern.UpdateEventArea
                               : UpdateSpCommandPattern.AdminUpdate.UpdateEventAreaAdm;
        }

        public string Command { get; private set; }
    }
}