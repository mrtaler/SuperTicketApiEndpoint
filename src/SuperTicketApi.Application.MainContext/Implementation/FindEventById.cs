namespace SuperTicketApi.Application.MainContext.Implementation
{
    using System;
    using System.Linq.Expressions;

    using SuperTicketApi.Domain.MainContext.Mssql.Models;
    using SuperTicketApi.Domain.Seedwork.Specifications.Specifications;

    public class FindEventById : Specification<Events>
    {
        /// <summary>
        /// The name.
        /// </summary>
        private int id;

        /// <summary>
        /// Initializes a new instance of the <see cref="FindEventById"/> class.
        /// </summary>
        /// <param name="id">
        /// The name.
        /// </param>
        public FindEventById(int id)
        {
            this.id = id;
        }

        /// <inheritdoc />
        public override Expression<Func<Events, bool>> AsExpression()
        {
            var parameter = Expression.Parameter(typeof(Events), "x");
            var member = Expression.Property(parameter, "Id");
            var constant = Expression.Constant(this.id);
            var body = Expression.Equal(member, constant);
            var finalExpression = Expression.Lambda<Func<Events, bool>>(body, parameter);

            return finalExpression;
        }
    }
}