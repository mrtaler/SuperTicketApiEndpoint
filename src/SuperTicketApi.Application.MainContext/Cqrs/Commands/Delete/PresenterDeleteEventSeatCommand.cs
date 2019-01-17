namespace SuperTicketApi.Application.MainContext.Cqrs.Commands.Delete
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.Command;

    /// <summary>
    /// The delete event seat command.
    /// </summary>
    public class PresenterDeleteEventSeatCommand : IBusinessCommand,
        IRequest<ApplicationCommandResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PresenterDeleteEventSeatCommand"/> class. 
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public PresenterDeleteEventSeatCommand(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public int Id { get; private set; }
    }
}