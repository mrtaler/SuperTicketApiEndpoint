namespace SuperTicketApi.Domain.MainContext.Command
{
    using System.Collections.Generic;

    using FluentValidation.Results;

    /// <summary>
    /// The Data Access Level command response.
    /// </summary>
    public class DomainCommandResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainCommandResponse"/> class.
        /// </summary>
        public DomainCommandResponse()
        {
            this.IsSuccess = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether is success.
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the object.
        /// </summary>
        public object Object { get; set; }

        /// <summary>
        /// Gets or sets the db validation errors.
        /// </summary>
        public List<string> DbValidationErrors { get; set; }

        /// <summary>
        /// Gets or sets the validation errors.
        /// </summary>
        public IList<ValidationFailure> ValidationErrors { get; set; }
    }
}
