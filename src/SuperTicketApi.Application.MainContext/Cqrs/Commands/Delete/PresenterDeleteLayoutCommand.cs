namespace SuperTicketApi.Application.MainContext.Cqrs.Commands.Delete
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.Command;

    /// <summary>
    /// The delete layout command.
    /// </summary>
    public class PresenterDeleteLayoutCommand : IBusinessCommand,
        IRequest<ApplicationCommandResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PresenterDeleteLayoutCommand"/> class. 
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public PresenterDeleteLayoutCommand(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public int Id { get; private set; }
    }
}