namespace SuperTicketApi.ApiEndpoint.ViewModel
{
    using System.Collections.Generic;

    using SuperTicketApi.Infrastructure.Crosscutting.Adapter;

    /// <summary>
    /// The projections extension methods.
    /// </summary>
    public static class ApiViewModelExtensionMethods
    {
        /// <summary>
        /// Project a type using a DTO
        /// </summary>
        /// <typeparam name="TProjection">The dto projection</typeparam>
        /// <param name="item">The source entity to project</param>
        /// <returns>The projected type</returns>
        public static TProjection ProjectedAs<TProjection>(this ApiViewModel item)
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
        public static List<TProjection> ProjectedAsCollection<TProjection>(this IEnumerable<ApiViewModel> items)
            where TProjection : class, new()
        {
            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<List<TProjection>>(items);
        }
    }
}