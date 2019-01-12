namespace SuperTicketApi.Domain.MainContext.DTO.Attributes
{
    using System;

    /// <summary>
    /// The id column attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IdColumnAttribute : DbColumnAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdColumnAttribute"/> class.
        /// </summary>
        /// <param name="classType">
        /// The class type.
        /// </param>
        public IdColumnAttribute(Type classType) : base($"{classType.Name}Id")
        {
        }
    }
}