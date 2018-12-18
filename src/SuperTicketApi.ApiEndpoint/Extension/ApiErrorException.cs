namespace SuperTicketApi.ApiEndpoint.Extension
{
    using System;
    using System.Runtime.Serialization;

    public abstract class ApiErrorException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiErrorException"/> class.
        /// </summary>
        /// <param name="message">
        /// The error message.
        /// </param>
        protected ApiErrorException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiErrorException"/> class.
        /// </summary>
        /// <param name="message">
        /// The error message.
        /// </param>
        /// <param name="innerException">
        /// The inner Exception.
        /// </param>
        protected ApiErrorException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiErrorException"/> class.
        /// </summary>
        protected ApiErrorException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiErrorException"/> class.
        /// </summary>
        /// <param name="info">
        /// The Serialization info.
        /// </param>
        /// <param name="context">
        /// The Streaming context.
        /// </param>
        protected ApiErrorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// A user-visible description of the error.
        /// </summary>
        public abstract string Description { get; }
    }
}