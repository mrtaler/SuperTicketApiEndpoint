namespace SuperTicketApi.Domain.MainContext.Command
{
    using System.Collections.Generic;

    /// <summary>
    /// The Data Access Level command response.
    /// </summary>
    public class DalCommandResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DalCommandResponse"/> class.
        /// </summary>
        public DalCommandResponse()
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
    }
}
