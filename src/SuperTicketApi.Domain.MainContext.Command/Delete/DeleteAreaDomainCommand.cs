namespace SuperTicketApi.Domain.MainContext.Command.Delete
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Attributes;
    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The delete area command.
    /// </summary>
    public class DeleteAreaDomainCommand : IRequest<DomainCommandResponse>, IDomainCommand
    {
        public DeleteAreaDomainCommand()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteAreaDomainCommand"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public DeleteAreaDomainCommand(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        [IdColumn(typeof(Area))]
        public int Id { get; private set; }

        /// <summary>
        /// The command.
        /// </summary>
        public string Command => DeleteSpCommandPattern.DeleteArea;
    }
}