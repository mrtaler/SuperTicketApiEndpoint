namespace SuperTicketApi.Domain.MainContext.DTO.Attributes
{
    using System;

    public class DbTableAttribute : Attribute
    {
        public string TableName { get; set; }

        public DbTableAttribute(string tableName)
        {
            this.TableName = tableName;
        }
    }
}
