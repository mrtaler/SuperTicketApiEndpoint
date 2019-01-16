namespace SuperTicketApi.Application.MainContext.Cqrs.Commands.Delete
{
    using MediatR;

    using SuperTicketApi.Application.MainContext.Cqrs;

    /// <summary>
    /// The delete event area command.
    /// </summary>
    public class PresenterDeleteEventAreaCommand : IRequest<CommandResponse>, IBusinessCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PresenterDeleteEventAreaCommand"/> class. 
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public PresenterDeleteEventAreaCommand(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public int Id { get; private set; }
    }
}