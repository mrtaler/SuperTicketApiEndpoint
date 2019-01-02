namespace SuperTicketApi.Domain.MainContext.Mssql.Implimentation
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using SuperTicketApi.Domain.MainContext.Mssql.Models;
    using SuperTicketApi.Domain.Seedwork.Specifications.Interfaces;

    public class DbColumns<T> : IColumnSpecification<T> where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CityInclude"/> class.
        /// </summary>
        public DbColumns(IEnumerable<Expression<Func<T, string>>> columns)
        {
            this.Columns = new List<Expression<Func<T, string>>>();
            this.Columns.AddRange(columns);
        }

        public List<Expression<Func<T, string>>> Columns { get; set; }
    }
}
