namespace SuperTicketApi.Domain.MainContext.Queries
{
    using SuperTicketApi.Domain.MainContext.Queries.GetSingleDomainEntity;

    /// <summary>
    /// The by id single query pattern.
    /// </summary>
    public static class ByIdSingleQueryPattern
    {
        /// <summary>
        /// The get single area query.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="GetSingleAreaQuery"/>.
        /// </returns>
        public static GetSingleAreaQuery GetSingleAreaQuery(int id) => new GetSingleAreaQuery(id);

        /// <summary>
        /// The get single event area query.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="GetSingleEventAreaQuery"/>.
        /// </returns>
        public static GetSingleEventAreaQuery GetSingleEventAreaQuery(int id) => new GetSingleEventAreaQuery(id);

        /// <summary>
        /// The get single event query.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="GetSingleEventQuery"/>.
        /// </returns>
        public static GetSingleEventQuery GetSingleEventQuery(int id) => new GetSingleEventQuery(id);

        /// <summary>
        /// The get single event seat query.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="GetSingleEventSeatQuery"/>.
        /// </returns>
        public static GetSingleEventSeatQuery GetSingleEventSeatQuery(int id) => new GetSingleEventSeatQuery(id);

        /// <summary>
        /// The get single layout query.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="GetSingleLayoutQuery"/>.
        /// </returns>
        public static GetSingleLayoutQuery GetSingleLayoutQuery(int id) => new GetSingleLayoutQuery(id);

        /// <summary>
        /// The get single seat query.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="GetSingleSeatQuery"/>.
        /// </returns>
        public static GetSingleSeatQuery GetSingleSeatQuery(int id) => new GetSingleSeatQuery(id);

        /// <summary>
        /// The get single venue query.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="GetSingleVenueQuery"/>.
        /// </returns>
        public static GetSingleVenueQuery GetSingleVenueQuery(int id) => new GetSingleVenueQuery(id);
    }
}
