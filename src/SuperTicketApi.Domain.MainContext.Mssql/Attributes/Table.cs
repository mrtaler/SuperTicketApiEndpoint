using System;

namespace SuperTicketApi.Domain.MainContext.Mssql.Attributes
{
    internal class DbTable : Attribute
    {
        public string TableName { get; set; }

        public DbTable(string tableName)
        {
            this.TableName = tableName;
        }
    }
}
