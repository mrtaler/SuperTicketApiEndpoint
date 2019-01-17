namespace SuperTicketApi.Domain.MainContext.Command.Delete
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Attributes;
    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The delete event area command.
    /// </summary>
    public class DeleteEventAreaDomainCommand : IRequest<DomainCommandResponse>, IDomainCommand
    {
        public DeleteEventAreaDomainCommand()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteEventAreaDomainCommand"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public DeleteEventAreaDomainCommand(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        [IdColumn(typeof(EventArea))]
        public int Id { get; private set; }

        /// <summary>
        /// The command.
        /// </summary>
        public string Command => DeleteSpCommandPattern.DeleteEventArea;
    }
}