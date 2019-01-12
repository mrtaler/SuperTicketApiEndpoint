namespace SuperTicketApi.Domain.MainContext.Command.CreateCommands
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    public class UpdateLayoutCommand : Layout, IRequest<DalCommandResponse>
    {
        public UpdateLayoutCommand(bool isAdminMode = false)
        {
            this.Command = isAdminMode
                               ? UpdateSpCommandPattern.UpdateLayout
                               : UpdateSpCommandPattern.AdminUpdate.UpdateLayoutAdm;
        }

        public string Command { get; private set; }
    }
}