namespace SuperTicketApi.Application.Seedwork
{
    using System;
    using System.Collections.Generic;

    using SuperTicketApi.Infrastructure.Crosscutting.Localization;

    public class ApplicationValidationErrorsException
        : Exception
    {
        #region Constructor

        /// <summary>
        /// Create new instance of Application validation errors exception
        /// </summary>
        /// <param name="validationErrors">The collection of validation errors</param>
        public ApplicationValidationErrorsException(IEnumerable<string> validationErrors)
            : base(LocalizationFactory.CreateLocalResources().GetStringResource(LocalizationKeys.Application.ValidationException))
        {
            this.validationErrors = validationErrors;
        }

        #endregion

        #region Properties

        IEnumerable<string> validationErrors;

        /// <summary>
        /// Get or set the validation errors messages
        /// </summary>
        public IEnumerable<string> ValidationErrors
        {
            get
            {
                return this.validationErrors;
            }
        }

        #endregion
    }
}
