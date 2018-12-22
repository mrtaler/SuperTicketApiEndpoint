﻿namespace SuperTicketApi.Domain.Seedwork
{
    using System;

    /// <summary>
    /// The <see cref="AuditableEntity"/> interface.
    /// </summary>
    public interface IAuditableEntity
    {
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the last modified by.
        /// </summary>
        string LastModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the last modified at.
        /// </summary>
        DateTime LastModifiedAt { get; set; }
    }
}
