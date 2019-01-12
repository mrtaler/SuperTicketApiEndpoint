namespace SuperTicketApi.Domain.MainContext.Command.CreateCommands
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.Command.Delete;

    public class DeleteEventCommand : IRequest<DalCommandResponse>
    {
        public DeleteEventCommand(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
        public string Command => DeleteSpCommandPattern.DeleteEvent;
    }
}