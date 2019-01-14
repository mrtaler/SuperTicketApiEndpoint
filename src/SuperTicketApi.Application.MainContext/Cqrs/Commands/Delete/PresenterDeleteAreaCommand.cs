namespace SuperTicketApi.Application.MainContext.Cqrs.Commands.Delete
{
    using MediatR;

    using SuperTicketApi.Application.MainContext.Cqrs;

    /// <summary>
    /// The delete area command.
    /// </summary>
    public class PresenterDeleteAreaCommand : IRequest<CommandResponse>, IBusinessCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PresenterDeleteAreaCommand"/> class. 
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public PresenterDeleteAreaCommand(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public int Id { get; private set; }
    }
}