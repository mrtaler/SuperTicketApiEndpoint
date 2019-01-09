﻿namespace SuperTicketApi.Domain.MainContext.Mssql.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

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

    // method for add to each class when need to use column extension
    /*
    protected string GetPropertyName(Expression<Func<T, string>> expression)
    {
    var memberExpersion = (ConstantExpression)expression.Body;

        return memberExpersion.Value.ToString();
    }*/
}
