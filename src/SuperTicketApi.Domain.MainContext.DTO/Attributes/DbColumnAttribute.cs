namespace SuperTicketApi.Domain.MainContext.DTO.Attributes
{
    using System;

    /// <summary>
    /// The db column attribute.
    /// </summary>
    public class DbColumnAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbColumnAttribute"/> class.
        /// </summary>
        /// <param name="columnName">
        /// The column name.
        /// </param>
        public DbColumnAttribute(string columnName)
        {
            this.ColumnName = columnName;
        }

        /// <summary>
        /// Gets or sets the column name.
        /// </summary>
        public string ColumnName { get; set; }
    }
}
