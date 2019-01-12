namespace SuperTicketApi.Domain.MainContext.Command.Delete
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Attributes;
    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The delete layout command.
    /// </summary>
    public class DeleteLayoutCommand : IRequest<CommandResponse>, IDomainCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteLayoutCommand"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public DeleteLayoutCommand(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        [IdColumn(typeof(Layout))]
        public int Id { get; private set; }

        /// <summary>
        /// The command.
        /// </summary>
        public string Command => DeleteSpCommandPattern.DeleteLayout;
    }
}