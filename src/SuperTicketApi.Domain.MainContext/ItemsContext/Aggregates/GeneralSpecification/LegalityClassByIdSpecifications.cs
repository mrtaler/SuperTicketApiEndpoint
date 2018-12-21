namespace SuperTicketApi.Domain.MainContext.ItemsContext.Aggregates.GeneralSpecification
{
    using System;
    using System.Linq.Expressions;

    using SuperTicketApi.Domain.Seedwork.Specifications.Specifications;

    /// <summary>
    /// The legality class by id specifications.
    /// </summary>
    public class LegalityClassByIdSpecifications : Specification<LegalityClass>
    {
        /// <summary>
        /// The name.
        /// </summary>
        private readonly int itemId;

        /// <summary>
        /// Initializes a new instance of the <see cref="LegalityClassByIdSpecifications"/> class. 
        /// </summary>
        /// <param name="itemId">
        /// The item Id.
        /// </param>
        public LegalityClassByIdSpecifications(int itemId) => this.itemId = itemId;

        /// <summary>
        /// The as expression.
        /// </summary>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public override Expression<Func<LegalityClass, bool>> AsExpression()
        {
            return p => p.Id.Equals(this.itemId);
        }
    }
}
