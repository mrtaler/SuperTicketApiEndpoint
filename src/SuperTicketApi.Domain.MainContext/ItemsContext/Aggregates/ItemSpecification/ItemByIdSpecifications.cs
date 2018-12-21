namespace SuperTicketApi.Domain.MainContext.ItemsContext.Aggregates.ItemSpecification
{
    using System;
    using System.Linq.Expressions;

    using SuperTicketApi.Domain.Seedwork.Specifications.Specifications;

    public class ItemByIdSpecifications : Specification<Item>
    {
        /// <summary>
        /// The name.
        /// </summary>
        private readonly Guid itemId;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemByIdSpecifications"/> class.
        /// </summary>
        /// <param name="itemId"></param>
        public ItemByIdSpecifications(Guid itemId)
        {
            this.itemId = itemId;
        }

        public override Expression<Func<Item, bool>> AsExpression()
        {
            return p => p.ItemId.Equals(this.itemId);
        }
    }
}
