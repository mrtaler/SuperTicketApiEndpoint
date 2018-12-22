namespace SuperTicketApi.Infrastructure.Crosscutting.Implementation.Localization
{
    using System;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;

    using SuperTicketApi.Infrastructure.Crosscutting.Implementation.Resources;
    using SuperTicketApi.Infrastructure.Crosscutting.Localization;

    /// <summary>
    /// The resources manager.
    /// </summary>
    public class ResourcesManager : ILocalization
    {
        #region Members

        /// <summary>
        /// The resource manager.
        /// </summary>
        private readonly ResourceManager resourceManager;
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourcesManager"/> class.
        /// </summary>
        public ResourcesManager()
        {
            this.resourceManager = new ResourceManager(typeof(Messages));
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the resource manager.
        /// </summary>
        public ResourceManager ResourceManager => this.resourceManager;

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public string GetStringResource(string key)
        {
            return this.resourceManager.GetString(key);
        }

        /// <inheritdoc />
        public string GetStringResource(string key, CultureInfo culture)
        {
            return this.resourceManager.GetString(key, culture);
        }

        /// <inheritdoc />
        public string GetStringResource<T>(T key) where T : struct, IConvertible
        {
            return this.resourceManager.GetString(this.GetKeyFromEnum<T>(key));
        }

        /// <inheritdoc />
        public string GetStringResource<T>(T key, CultureInfo culture) where T : struct, IConvertible
        {
            return this.resourceManager.GetString(this.GetKeyFromEnum<T>(key), culture);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The get <paramref name="key"/> from enum.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <typeparam name="T">d d 
        /// </typeparam>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="ArgumentException">Argument Exception
        /// </exception>
        private string GetKeyFromEnum<T>(T key) where T : struct, IConvertible
        {
            if (!typeof(T).GetTypeInfo().IsEnum)
            {
                throw new ArgumentException(LocalizationFactory.CreateLocalResources().GetStringResource(LocalizationKeys.Infrastructure.ExceptionInvalidEnumeratedType));
            }

            return $"{typeof(T).Name}_{key.ToString()}";
        }

        #endregion
    }
}
