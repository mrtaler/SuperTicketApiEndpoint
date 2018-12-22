namespace SuperTicketApi.Domain.MainContext.ItemsContext.Aggregates
{
    using SuperTicketApi.Domain.Seedwork.Repository;

    /// <summary>
    /// The TechnicalLevelRepository <see langword="interface"/>.
    /// </summary>
    public interface ITechnicalLevelRepository
        : IRepository<TechnicalLevel>
    {
    }
}