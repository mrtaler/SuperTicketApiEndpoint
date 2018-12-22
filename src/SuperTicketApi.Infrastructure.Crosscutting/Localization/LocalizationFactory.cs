namespace SuperTicketApi.Infrastructure.Crosscutting.Localization
{
    /// <summary>
    /// The localization factory.
    /// </summary>
    public static class LocalizationFactory
    {
        #region Members

        /// <summary>
        /// The current local resources factory.
        /// </summary>
        private static ILocalizationFactory currentLocalResourcesFactory;

        #endregion

        #region Public Methods        

        /// <summary>
        /// The set current.
        /// </summary>
        /// <param name="currentLocResourcesFactory">
        /// The current local resources factory.
        /// </param>
        public static void SetCurrent(ILocalizationFactory currentLocResourcesFactory)
        {
            currentLocalResourcesFactory = currentLocResourcesFactory;
        }

        /// <summary>
        /// The create local resources.
        /// </summary>
        /// <returns>
        /// The <see cref="ILocalization"/>.
        /// </returns>
        public static ILocalization CreateLocalResources()
        {
            return currentLocalResourcesFactory?.Create();
        }

        #endregion
    }
}
