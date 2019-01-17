namespace SuperTicketApi.Application.MainContext.Cqrs.Commands.Delete
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.Command;

    /// <summary>
    /// The delete seat command.
    /// </summary>
    public class PresenterDeleteSeatCommand : IBusinessCommand,
        IRequest<ApplicationCommandResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PresenterDeleteSeatCommand"/> class. 
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public PresenterDeleteSeatCommand(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public int Id { get; private set; }
    }
}