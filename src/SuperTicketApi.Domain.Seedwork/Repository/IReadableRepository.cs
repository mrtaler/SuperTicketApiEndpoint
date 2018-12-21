namespace SuperTicketApi.Domain.Seedwork.Repository
{
    using System.Collections.Generic;

    using SuperTicketApi.Domain.Seedwork.Specifications.Interfaces;

    /// <summary>
    /// The ReadableRepository interface.
    /// </summary>
    /// <typeparam name="TEntity"> db Entity
    /// </typeparam>
    public interface IReadableRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Get element by entity key
        /// </summary>
        /// <param name="id">Entity key value</param>
        /// <returns>Db Entity</returns>
        TEntity Get(object id);

        /// <summary>
        /// Get all elements of type TEntity in repository
        /// </summary>
        /// <returns>List of selected elements</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// The get all.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <param name="orderBy">
        /// The order by.
        /// </param>
        /// <param name="includes">
        /// The include specification.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        IEnumerable<TEntity> AllMatching(
            ISpecification<TEntity> filter = null,
            IOrderSpecification<TEntity> orderBy = null,
            IIncludeSpecification<TEntity> includes = null);

        /// <summary>
        /// Get the first element of type TEntity that matching a
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
        TEntity OneMatching(
            ISpecification<TEntity> filter = null,
            IOrderSpecification<TEntity> orderBy = null,
            IIncludeSpecification<TEntity> includes = null);
    }
}
