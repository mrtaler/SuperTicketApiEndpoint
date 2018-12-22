namespace SuperTicketApi.Infrastructure.Crosscutting.Localization
{
    using System;
    using System.Globalization;

    /// <summary>
    /// The Localization <see langword="interface"/>.
    /// </summary>
    public interface ILocalization
    {
        /// <summary>
        /// The get string resource.
        /// </summary>
        /// <param name="key"> The key. </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string GetStringResource(string key);

        /// <summary>
        /// The get string resource.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string GetStringResource(string key, CultureInfo culture);

        /// <summary>
        /// The get string resource.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string GetStringResource<T>(T key) where T : struct, IConvertible;

        /// <summary>
        /// The get string resource.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string GetStringResource<T>(T key, CultureInfo culture) where T : struct, IConvertible;
    }
}
