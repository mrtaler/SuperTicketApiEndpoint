namespace SuperTicketApi.Domain.Seedwork
{
    using System;

    /// <summary>
    /// The auditable entity.
    /// </summary>
    public abstract class AuditableEntity : Entity, IAuditableEntity
    {
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the last modified by.
        /// </summary>
        public string LastModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the last modified at.
        /// </summary>
        public DateTime LastModifiedAt { get; set; }
    }
}
