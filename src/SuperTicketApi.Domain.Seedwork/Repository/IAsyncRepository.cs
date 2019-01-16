namespace SuperTicketApi.Domain.Seedwork.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// The <c>AsyncRepository</c> <c>interface</c>.
    /// </summary>
    /// <typeparam name="TEntity">Ef Class
    /// </typeparam>
    public interface IAsyncRepository<TEntity>
        where TEntity : DomainEntity, new()
    {
        /// <summary>
        /// Get element by entity key - Async
        /// </summary>
        /// <param name="id"><see cref="Entity"/> key value</param>
        /// <returns>Db Entity</returns>
        Task<TEntity> GetAsync(object id);

        /// <summary>
        /// Get all elements of type TEntity in repository - Async
        /// </summary>
        /// <returns>List of selected elements</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /*
                /// <summary>
                /// The get <see langword="async"/>.
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
                /// <param name="filter">
                /// The filter.
                /// </param>
                /// <param name="orderBy">
                /// The order By.
                /// </param>
                /// <param name="includes">
                /// The includes.
                /// </param>
                /// <returns>
                /// Db Entity
                /// </returns>
                Task<TEntity> OneMatchingAsync(
                    ISpecification<TEntity> filter = null,
                    IOrderSpecification<TEntity> orderBy = null,
                    IIncludeSpecification<TEntity> includes = null);
                    */
    }
}
