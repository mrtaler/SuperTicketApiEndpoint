namespace SuperTicketApi.Application.MainContext.Cqrs.Commands.Delete
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.Command;

    /// <summary>
    /// The delete event command.
    /// </summary>
    public class PresenterDeleteEventCommand : IRequest<CommandResponse>, IBusinessCommand
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