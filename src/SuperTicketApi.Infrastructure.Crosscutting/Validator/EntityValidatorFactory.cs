namespace SuperTicketApi.Infrastructure.Crosscutting.Validator
{
    /// <summary>
    /// The entity <c>validator</c> factory.
    /// </summary>
    public static class EntityValidatorFactory
    {
        #region Members

        /// <summary>
        /// The factory.
        /// </summary>
        private static IEntityValidatorFactory factory;

        #endregion

        #region Public Methods

        /// <summary>
        /// Set the  log <see cref="factory"/> to use
        /// </summary>
        /// <param name="fact">Log factory to use</param>
        public static void SetCurrent(IEntityValidatorFactory fact)
        {
            factory = fact;
        }

        /// <summary>
        /// Create the validator <c>factory</c>
        /// </summary>
        /// <returns>Entity Validator</returns>
        public static IEntityValidator CreateValidator()
        {
            return factory?.Create();
        }

        #endregion
    }
}
