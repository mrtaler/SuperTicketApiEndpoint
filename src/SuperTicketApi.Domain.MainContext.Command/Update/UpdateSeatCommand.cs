namespace SuperTicketApi.Domain.MainContext.Command.CreateCommands
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    public class UpdateSeatCommand : Seat, IRequest<DalCommandResponse>
    {
        public UpdateSeatCommand(bool isAdminMode = false)
        {
            this.Command = isAdminMode
                               ? UpdateSpCommandPattern.UpdateSeat
                               : UpdateSpCommandPattern.AdminUpdate.UpdateSeatAdm;
        }

        public string Command { get; private set; }
    }
}