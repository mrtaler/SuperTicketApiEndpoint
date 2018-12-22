namespace SuperTicketApi.Infrastructure.Crosscutting.Validator
{
    /// <summary>
    /// Base contract for entity validator <c>abstract</c> factory
    /// </summary>
    public interface IEntityValidatorFactory
    {
        /// <summary>
        /// Create a new <c>IEntityValidator</c>
        /// </summary>
        /// <returns>IEntity Validator</returns>
        IEntityValidator Create();
    }
}
