namespace SuperTicketApi.Domain.MainContext.DTO.Attributes
{
    using System;

    public class DbColumnAttribute : Attribute
    {
        public string columnName { get; set; }
        public DbColumnAttribute(string columnName)
        {
            this.columnName = columnName;
        }
    }
}
