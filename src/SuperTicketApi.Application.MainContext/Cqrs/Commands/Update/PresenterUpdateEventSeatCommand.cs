namespace SuperTicketApi.Application.MainContext.Cqrs.Commands.Create
{
    using MediatR;

    /// <summary>
    /// The presenter create event seat command.
    /// </summary>
    public class PresenterUpdateEventSeatCommand : IRequest<CommandResponse>, IBusinessCommand
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the event areas id.
        /// </summary>
        public int EventAreaId { get; set; }

        /// <summary>
        /// Gets or sets the row.
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public int State { get; set; }
    }
}