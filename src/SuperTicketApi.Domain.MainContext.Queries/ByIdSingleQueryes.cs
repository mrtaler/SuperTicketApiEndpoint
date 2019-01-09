using SuperTicketApi.Domain.MainContext.Queries.GetSingleDomainEntity;

namespace SuperTicketApi.Domain.MainContext.Queries
{
    public static class ByIdSingleQueryes
    {
        /// <summary>
        /// 1.Gets the single area query.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static GetSingleAreaQuery GetSingleAreaQuery(int id) => new GetSingleAreaQuery(id);

        /// <summary>
        /// 2.Gets the single event area query.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static GetSingleEventAreaQuery GetSingleEventAreaQuery(int id) => new GetSingleEventAreaQuery(id);

        /// <summary>
        /// 3.Gets the single event query.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static GetSingleEventQuery GetSingleEventQuery(int id) => new GetSingleEventQuery(id);

        /// <summary>
        /// 4.Gets the single event seat query.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static GetSingleEventSeatQuery GetSingleEventSeatQuery(int id) => new GetSingleEventSeatQuery(id);

        /// <summary>
        /// 5.Gets the single layout query.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static GetSingleLayoutQuery GetSingleLayoutQuery(int id) => new GetSingleLayoutQuery(id);

        /// <summary>
        /// 6.Gets the single seat query.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static GetSingleSeatQuery GetSingleSeatQuery(int id) => new GetSingleSeatQuery(id);

        /// <summary>
        /// 7.Gets the single venue query.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static GetSingleVenueQuery GetSingleVenueQuery(int id) => new GetSingleVenueQuery(id);

    }
}
