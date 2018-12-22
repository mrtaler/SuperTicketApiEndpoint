namespace SuperTicketApi.Infrastructure.Crosscutting.Localization
{
    /// <summary>
    /// The Localization Factory <see langword="interface"/>.
    /// </summary>
    public interface ILocalizationFactory
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <returns>
        /// The <see cref="ILocalization"/>.
        /// </returns>
        ILocalization Create();
    }
}
