namespace SuperTicketApi.Domain.MainContext.DTO.Attributes
{
    using System;
    using System.Linq;

    /// <summary>
    /// The attribute extensions.
    /// </summary>
    public static class AttributeExtensions
    {
        /// <summary>
        /// The get attribute value.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="valueSelector">
        /// The value selector.
        /// </param>
        /// <typeparam name="TAttribute">Current attribute
        /// </typeparam>
        /// <typeparam name="TValue">Get Value
        /// </typeparam>
        /// <returns>
        /// The <see cref="TValue"/>.
        /// </returns>
        public static TValue GetAttributeValue<TAttribute, TValue>(
            this Type type,
            Func<TAttribute, TValue> valueSelector)
            where TAttribute : Attribute
        {
            if (type.GetCustomAttributes(
                        typeof(TAttribute), true)
                    .FirstOrDefault() is TAttribute att)
            {
                return valueSelector(att);
            }

            return default(TValue);
        }
    }
}
