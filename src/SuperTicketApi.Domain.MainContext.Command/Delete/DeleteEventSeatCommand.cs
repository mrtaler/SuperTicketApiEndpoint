namespace SuperTicketApi.Domain.MainContext.Command.Delete
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Attributes;
    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The delete event seat command.
    /// </summary>
    public class DeleteEventSeatCommand : IRequest<CommandResponse>, IDomainCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteEventSeatCommand"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public DeleteEventSeatCommand(int id)
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