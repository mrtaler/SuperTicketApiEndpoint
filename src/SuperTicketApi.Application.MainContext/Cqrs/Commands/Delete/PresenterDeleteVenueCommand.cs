namespace SuperTicketApi.Application.MainContext.Cqrs.Commands.Delete
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.Command;

    /// <summary>
    /// The delete venue command.
    /// </summary>
    public class PresenterDeleteVenueCommand : IBusinessCommand,
        IRequest<ApplicationCommandResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PresenterDeleteVenueCommand"/> class. 
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public PresenterDeleteVenueCommand(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public int Id { get; private set; }
    }
}