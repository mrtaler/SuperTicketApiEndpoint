using MediatR;
using SuperTicketApi.Domain.MainContext.DTO.Models;

namespace SuperTicketApi.Domain.MainContext.Command.CreateCommands
{
    public class UpdateAreaCommand : Area, IRequest<DalCommandResponse>
    {
        public UpdateAreaCommand() { }


        public UpdateAreaCommand(bool isAdminMode = false)
        {
            this.Command = isAdminMode
                ? UpdateSpCommandPattern.UpdateArea
                : UpdateSpCommandPattern.AdminUpdate.UpdateAreaAdm;
        }

        public string Command { get; private set; }
    }
}