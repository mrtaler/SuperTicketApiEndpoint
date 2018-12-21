namespace SuperTicketApi.Domain.Seedwork.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SuperTicketApi.Domain.Seedwork.Specifications.Interfaces;

    /// <summary>
    /// The AsyncRepository interface.
    /// </summary>
    /// <typeparam name="TEntity">Ef Class
    /// </typeparam>
    public interface IAsyncRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Get element by entity key - Async
        /// </summary>
        /// <param name="id">Entity key value</param>
        /// <returns>Db Entity</returns>
        Task<TEntity> GetAsync(object id);

        /// <summary>
        /// Get all elements of type TEntity in repository - Async
        /// </summary>
        /// <returns>List of selected elements</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// The get async.
        /// </summary>
        /// <param name="filter">
        /// The specification.
        /// </param>
        /// <param name="orderBy">
        /// The orderby.
        /// </param>
        /// <param name="includes">
        /// The include specification.
        /// </param>
        /// <returns>
        /// The <see cref="Task{TResult}"/>.
        /// </returns>
        Task<IEnumerable<TEntity>> AllMatchingAsync(
            ISpecification<TEntity> filter = null,
            IOrderSpecification<TEntity> orderBy = null,
            IIncludeSpecification<TEntity> includes = null);

        /// <summary>
        /// Get the first element of type TEntity that matching a - Async
        /// Specification <paramref name="specification"/>
        /// </summary>
        /// <param name="specification">
        /// Specification that result meet
        /// </param>
        /// <param name="orderBy">
        /// The order By.
        /// </param>
        /// <returns>Db Entity
        /// </returns>
        Task<TEntity> OneMatchingAsync(
            ISpecification<TEntity> filter = null,
            IOrderSpecification<TEntity> orderBy = null,
            IIncludeSpecification<TEntity> includes = null);
    }
}
