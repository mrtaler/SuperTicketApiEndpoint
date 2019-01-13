namespace SuperTicketApi.Domain.MainContext.Mssql
{
    using System.Collections.Generic;

    using SuperTicketApi.Domain.MainContext.Command;
    using SuperTicketApi.Infrastructure.Crosscutting.Adapter;

    /// <summary>
    /// The projections extension methods.
    /// </summary>
    public static class DomainProjectionsExtensionMethods
    {
        /// <summary>
        /// Project a type using a DTO
        /// </summary>
        /// <typeparam name="TProjection">
        /// The dto projection
        /// </typeparam>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The projected type
        /// </returns>
        public static TProjection ProjectedAs<TProjection>(this IDomainCommand item)
            where TProjection : class, new()
        {
            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<TProjection>(item);
        }

        /// <summary>
        /// projected a enumerable collection of items
        /// </summary>
        /// <typeparam name="TProjection">The dtop projection type</typeparam>
        /// <param name="items">the collection of entity items</param>
        /// <returns>Projected collection</returns>
        public static List<TProjection> ProjectedAsCollection<TProjection>(this IEnumerable<IDomainCommand> items)
            where TProjection : class, new()
        {
            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<List<TProjection>>(items);
        }
    }
}