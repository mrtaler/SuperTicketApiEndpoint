namespace SuperTicketApi.Application.MainContext.Cqrs.Commands.Update
{
    using MediatR;

    /// <summary>
    /// The presenter create layout command.
    /// </summary>
    public class PresenterUpdateLayoutCommand : IRequest<CommandResponse>, IBusinessCommand
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the venue id.
        /// </summary>
        public int VenueId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }
    }
}