namespace SuperTicketApi.Domain.MainContext.Command.Delete
{
    using MediatR;

    /// <summary>
    /// The delete event area command.
    /// </summary>
    public class DeleteEventAreaCommand : IRequest<DalCommandResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteEventAreaCommand"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public DeleteEventAreaCommand(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// The command.
        /// </summary>
        public string Command => DeleteSpCommandPattern.DeleteEventArea;
    }
}