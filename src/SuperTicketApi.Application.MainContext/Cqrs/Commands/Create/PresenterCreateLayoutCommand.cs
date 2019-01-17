namespace SuperTicketApi.Application.MainContext.Cqrs.Commands.Create
{
    using MediatR;

    /// <summary>
    /// The presenter create layout command.
    /// </summary>
    public class PresenterCreateLayoutCommand : IRequest<ApplicationCommandResponse>, IBusinessCommand
    {
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