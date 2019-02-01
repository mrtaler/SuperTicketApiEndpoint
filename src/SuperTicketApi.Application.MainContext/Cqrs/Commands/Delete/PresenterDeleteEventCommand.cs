namespace SuperTicketApi.Application.MainContext.Cqrs.Commands.Delete
{
    using MediatR;

    /// <summary>
    /// The delete event command.
    /// </summary>
    public class PresenterDeleteEventCommand : IBusinessCommand,
        IRequest<ApplicationCommandResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PresenterDeleteEventCommand"/> class. 
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public PresenterDeleteEventCommand(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public int Id { get; private set; }
    }
}