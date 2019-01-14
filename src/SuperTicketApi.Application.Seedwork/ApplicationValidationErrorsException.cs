namespace SuperTicketApi.Application.Seedwork
{
    using System;
    using System.Collections.Generic;

    using SuperTicketApi.Infrastructure.Crosscutting.Localization;

    /// <summary>
    /// The application validation errors exception.
    /// </summary>
    public class ApplicationValidationErrorsException
        : Exception
    {
        /// <summary>
        /// The validation errors.
        /// </summary>
        private readonly IEnumerable<string> validationErrors;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationValidationErrorsException"/> class. 
        /// Create new instance of Application validation errors exception
        /// </summary>
        /// <param name="validationErrors">
        /// The collection of validation errors
        /// </param>
        public ApplicationValidationErrorsException(IEnumerable<string> validationErrors)
            : base(LocalizationFactory.CreateLocalResources().GetStringResource(LocalizationKeys.Application.ValidationException))
        {
            this.validationErrors = validationErrors;
        }

        /// <summary>
        /// Get or set the validation errors messages
        /// </summary>
        public IEnumerable<string> ValidationErrors => this.validationErrors;
    }
}
