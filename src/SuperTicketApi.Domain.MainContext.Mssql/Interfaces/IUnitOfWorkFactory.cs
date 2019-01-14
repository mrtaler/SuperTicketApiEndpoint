namespace SuperTicketApi.Domain.MainContext.Mssql.Interfaces
{
    using SuperTicketApi.Domain.Seedwork;

    /// <summary>
    /// The UnitOfWorkFactory interface.
    /// </summary>
    public interface IUnitOfWorkFactory
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <returns>
        /// The <see cref="INetUnitOfWork"/>.
        /// </returns>
        INetUnitOfWork Create();

        /// <summary>
        /// The create transactional.
        /// </summary>
        /// <returns>
        /// The <see cref="INetUnitOfWork"/>.
        /// </returns>
        INetUnitOfWork CreateTransactional();
    }
}
