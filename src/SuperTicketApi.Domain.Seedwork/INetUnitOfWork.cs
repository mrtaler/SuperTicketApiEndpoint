namespace SuperTicketApi.Domain.Seedwork
{
    using System;
    using System.Data;

    /// <summary>
    /// The NetUnitOfWork <see langword="interface"/>.
    /// </summary>
    public interface INetUnitOfWork : IDisposable
    {
        /// <summary>
        /// The create command.
        /// </summary>
        /// <returns>
        /// The <see cref="IDbCommand"/>.
        /// </returns>
        IDbCommand CreateCommand();

        /// <summary>
        /// The save change.
        /// </summary>
        void SaveChange();
    }
}