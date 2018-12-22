namespace SuperTicketApi.Domain.MainContext.ItemsContext.Aggregates
{
    using SuperTicketApi.Domain.Seedwork.Repository;

    /// <summary>
    /// The ItemRepository <see langword="interface"/>.
    /// </summary>
    public interface IItemRepository
        : IRepository<Item>
    {
    }
}
