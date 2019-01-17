namespace SuperTicketApi.Domain.MainContext.DTO.Attributes
{
    using System;

    /// <summary>
    /// The db table attribute.
    /// </summary>
    public class DbTableAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbTableAttribute"/> class.
        /// </summary>
        /// <param name="tableName">
        /// The table name.
        /// </param>
        public DbTableAttribute(string tableName)
        {
            this.TableName = tableName;
        }

        /// <summary>
        /// Gets or sets the table name.
        /// </summary>
        public string TableName { get; set; }
    }
}
