namespace SuperTicketApi.Infrastructure.Crosscutting.Implementation.Localization
{
    using System;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;

    using SuperTicketApi.Infrastructure.Crosscutting.Implementation.Resources;
    using SuperTicketApi.Infrastructure.Crosscutting.Localization;

    public class ResourcesManager : ILocalization
    {
        #region Members

        private ResourceManager resourceManager;
        #endregion

        #region Properties
        public ResourceManager ResourceManager
        {
            get { return this.resourceManager; }
        }
        #endregion

        #region Constructor
        public ResourcesManager()
        {
            this.resourceManager = new ResourceManager(typeof(Messages));
        }

        #endregion

        #region Private Methods
        private string GetKeyFromEnum<T>(T key) where T : struct, IConvertible
        {
            if (!typeof(T).GetTypeInfo().IsEnum)
            {
                throw new ArgumentException(LocalizationFactory.CreateLocalResources().GetStringResource(LocalizationKeys.Infrastructure.exception_InvalidEnumeratedType));
            }

            return string.Format("{0}_{1}", typeof(T).Name, key.ToString());
        }

        #endregion

        #region Public Methods
        public string GetStringResource(string key)
        {
            return this.resourceManager.GetString(key);
        }

        public string GetStringResource(string key, CultureInfo culture)
        {
            return this.resourceManager.GetString(key, culture);
        }

        public string GetStringResource<T>(T key) where T : struct, IConvertible
        {
            return this.resourceManager.GetString(this.GetKeyFromEnum<T>(key));
        }

        public string GetStringResource<T>(T key, CultureInfo culture) where T : struct, IConvertible
        {
            return this.resourceManager.GetString(this.GetKeyFromEnum<T>(key), culture);
        }

        #endregion
    }
}
