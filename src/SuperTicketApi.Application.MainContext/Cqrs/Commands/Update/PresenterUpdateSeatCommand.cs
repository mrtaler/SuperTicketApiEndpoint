namespace SuperTicketApi.Application.MainContext.Cqrs.Commands.Update
{
    using MediatR;

    /// <summary>
    /// The presenter create seat command.
    /// </summary>
    public class PresenterUpdateSeatCommand : IRequest<ApplicationCommandResponse>, IBusinessCommand
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the area id.
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// Gets or sets the row.
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        public int Number { get; set; }
    }
}