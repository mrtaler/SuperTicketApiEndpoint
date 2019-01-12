namespace SuperTicketApi.Domain.MainContext.Command.CreateCommands
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.Command.Delete;

    public class DeleteLayoutCommand : IRequest<DalCommandResponse>
    {
        public DeleteLayoutCommand(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
        public string Command => DeleteSpCommandPattern.DeleteLayout;
    }
}