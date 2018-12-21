namespace SuperTicketApi.Domain.Seedwork
{
    /// <summary>
    /// The Entity interface.
    /// </summary>
    /// <typeparam name="T">you type for ID Key
    /// </typeparam>
    public interface IEntity<T>
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        T Id { get; set; }
    }
}
