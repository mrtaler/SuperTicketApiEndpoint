namespace SuperTicketApi.Domain.MainContext.DTO.Attributes
{
    using System;

    internal class DbColumnAttribute : Attribute
    {
        public string columnName { get; set; }
        public DbColumnAttribute(string columnName)
        {
            this.columnName = columnName;
        }
    }
}
