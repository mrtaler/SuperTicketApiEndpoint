using System;

namespace SuperTicketApi.Domain.MainContext.Mssql.Attributes
{
    internal class DbColumn : Attribute
    {
        public string columnName { get; set; }
        public DbColumn(string columnName)
        {
            this.columnName = columnName;
        }
    }
}
