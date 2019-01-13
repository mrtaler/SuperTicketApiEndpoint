namespace SuperTicketApi.Domain.MainContext.Command
{
    /// <summary>
    /// The DomainCommand interface.
    /// </summary>
    public interface IDomainCommand
    {
        /// <summary>
        /// Gets the command.
        /// </summary>
        string Command { get; }
    }
}