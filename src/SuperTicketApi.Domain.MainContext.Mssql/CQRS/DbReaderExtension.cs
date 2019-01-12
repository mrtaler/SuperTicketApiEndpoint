namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS
{
    using System;
    using System.Data;
    using System.Globalization;

    /// <summary>
    /// The db reader extension.
    /// </summary>
    public static class DbReaderExtension
    {
        /// <summary>
        /// The get value as string.
        /// </summary>
        /// <param name="reader">
        /// The reader.
        /// </param>
        /// <param name="fieldName">
        /// The field name.
        /// </param>
        /// <typeparam name="T"> type of dbValue
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/> type of dbValue
        /// </returns>
        public static T GetTypedValue<T>(
            this IDataReader reader,
            string fieldName) where T : class
        {
            return reader[fieldName] is DBNull
                       ? null
                       : (T)Convert.ChangeType(reader[fieldName], typeof(T), CultureInfo.InvariantCulture);
        }
    }
}