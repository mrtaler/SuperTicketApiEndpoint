namespace SuperTicketApi.Domain.MainContext.DTO.Attributes
{
    using System;

    internal class DbTableAttribute : Attribute
    {
        public string TableName { get; set; }

        public DbTableAttribute(string tableName)
        {
            this.TableName = tableName;
        }
    }
}
