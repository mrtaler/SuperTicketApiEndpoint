namespace SuperTicketApi.Domain.MainContext.ItemsContext.Aggregates
{
    /// <summary>
    /// The item factory.
    /// </summary>
    public static class ItemFactory
    {
        /// <summary>
        /// The create item.
        /// </summary>
        /// <returns>
        /// The <see cref="Item"/>.
        /// </returns>
        public static Item CreateItem(TechnicalLevel tl, LegalityClass lc)
        {
            var item = new Item();
            item.GenerateNewIdentity();
            item.TechnicalLevel = tl;
            item.LegalityClass = lc;
            return item;
        }
    }
}