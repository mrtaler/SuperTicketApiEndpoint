namespace SuperTicketApi.Domain.MainContext.Command.Delete
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Attributes;
    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The delete event seat command.
    /// </summary>
    public class DeleteEventSeatDomainCommand : IRequest<DomainCommandResponse>, IDomainCommand
    {
        public DeleteEventSeatDomainCommand()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteEventSeatDomainCommand"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public DeleteEventSeatDomainCommand(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        [IdColumn(typeof(EventSeat))]
        public int Id { get; private set; }

        /// <summary>
        /// The command.
        /// </summary>
        public string Command => DeleteSpCommandPattern.DeleteEventSeat;
    }
}