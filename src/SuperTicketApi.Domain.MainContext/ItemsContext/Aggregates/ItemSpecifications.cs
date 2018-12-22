namespace SuperTicketApi.Domain.MainContext.ItemsContext.Aggregates
{
    using System;

    using SuperTicketApi.Domain.MainContext.ItemsContext.Aggregates.ItemSpecification;
    using SuperTicketApi.Domain.Seedwork.Specifications.Interfaces;
    using SuperTicketApi.Domain.Seedwork.Specifications.Specifications;

    /// <summary>
    /// The item specifications.
    /// </summary>
    public static class ItemSpecifications
    {
        /// <summary>
        /// The item by id.
        /// </summary>
        /// <param name="itemId">
        /// The item id.
        /// </param>
        /// <returns>
        /// The <see cref="ISpecification{T}"/>.
        /// </returns>
        public static ISpecification<Item> ItemById(Guid itemId)
        {
            Specification<Item> specification = new ItemByIdSpecifications(itemId);
            return specification;
        }
    }
}