namespace SuperTicketApi.Application.MainContext.Cqrs.Commands.Create
{
    using MediatR;

    /// <summary>
    /// The presenter create venue command.
    /// </summary>
    public class PresenterUpdateVenueCommand : IRequest<CommandResponse>, IBusinessCommand
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        public string Phone { get; set; }
    }
}