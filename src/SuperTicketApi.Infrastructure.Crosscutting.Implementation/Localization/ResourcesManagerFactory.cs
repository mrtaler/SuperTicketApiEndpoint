namespace SuperTicketApi.Infrastructure.Crosscutting.Implementation.Localization
{
    using SuperTicketApi.Infrastructure.Crosscutting.Localization;

    /// <summary>
    /// The resources manager factory.
    /// </summary>
    public class ResourcesManagerFactory : ILocalizationFactory
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <returns>
        /// The <see cref="ILocalization"/>.
        /// </returns>
        public ILocalization Create()
        {
            return new ResourcesManager();
        }
    }
}
