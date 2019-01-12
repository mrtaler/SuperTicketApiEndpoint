using SuperTicketApi.Domain.MainContext.Queries.GetListOfDomainEntity;

namespace SuperTicketApi.Domain.MainContext.Queries
{
    /// <summary>
    /// All Queries
    /// </summary>
    public static class EnumerableQueryes
    {
        /// <summary>
        /// 1.Gets the get area as i enumerable query.
        /// </summary>
        /// <value>
        /// The get area as i enumerable query.
        /// </value>
        public static GetAreaAsIEnumerableQuery GetAreaAsIEnumerableQuery => new GetAreaAsIEnumerableQuery();
        

        /// <summary>
        /// 2.Gets the get event area as i enumerable query.
        /// </summary>
        /// <value>
        /// The get event area as i enumerable query.
        /// </value>
        public static GetEventAreaAsIEnumerableQuery GetEventAreaAsIEnumerableQuery => new GetEventAreaAsIEnumerableQuery();
        

        /// <summary>
        /// 3.Gets the get event as i enumerable query.
        /// </summary>
        /// <value>
        /// The get event as i enumerable query.
        /// </value>
        public static GetEventAsIEnumerableQuery GetEventAsIEnumerableQuery => new GetEventAsIEnumerableQuery();
        

        /// <summary>
        /// 4.Gets the get event seat as i enumerable query.
        /// </summary>
        /// <value>
        /// The get event seat as i enumerable query.
        /// </value>
        public static GetEventSeatAsIEnumerableQuery GetEventSeatAsIEnumerableQuery => new GetEventSeatAsIEnumerableQuery();
        

        /// <summary>
        /// 5.Gets the get layout as i enumerable query.
        /// </summary>
        /// <value>
        /// The get layout as i enumerable query.
        /// </value>
        public static GetLayoutAsIEnumerableQuery GetLayoutAsIEnumerableQuery => new GetLayoutAsIEnumerableQuery();
        

        /// <summary>
        /// 6.Gets the get seat as i enumerable query.
        /// </summary>
        /// <value>
        /// The get seat as i enumerable query.
        /// </value>
        public static GetSeatAsIEnumerableQuery GetSeatAsIEnumerableQuery => new GetSeatAsIEnumerableQuery();
        

        /// <summary>
        /// 7.Gets the get venue as i enumerable query.
        /// </summary>
        /// <value>
        /// The get venue as i enumerable query.
        /// </value>
        public static GetVenueAsIEnumerableQuery GetVenueAsIEnumerableQuery => new GetVenueAsIEnumerableQuery();
    }
}
