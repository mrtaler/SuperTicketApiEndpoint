namespace SuperTicketApi.ApiEndpoint.Controllers.Base
{
    using System.Collections.Generic;

    /// <summary>
    /// The base controller.
    /// </summary>
    public partial class BaseController
    {
        /// <summary>
        /// The validation error.
        /// </summary>
        protected class ApiValidationError
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ApiValidationError"/> class.
            /// </summary>
            public ApiValidationError()
            {
                PlaceHolder = new Dictionary<string, string>();
            }

            /// <summary>
            /// Gets or sets the property name.
            /// </summary>
            public string PropertyName { get; set; }

            /// <summary>
            /// Gets or sets the attempted value.
            /// </summary>
            public string AttemptedValue { get; set; }

            /// <summary>
            /// Gets or sets the error message.
            /// </summary>
            public string ErrorMessage { get; set; }

            /// <summary>
            /// Gets or sets the custom state.
            /// </summary>
            public string CustomState { get; set; }

            /// <summary>
            /// Gets or sets the error code.
            /// </summary>
            public string ErrorCode { get; set; }

            /// <summary>
            /// Gets or sets the place holder.
            /// </summary>
            public Dictionary<string, string> PlaceHolder { get; set; }
        }


    }
}