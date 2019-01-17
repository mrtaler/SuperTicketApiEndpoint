namespace SuperTicketApi.Domain.MainContext.DTO.Models
{
    using System;

    using SuperTicketApi.Domain.MainContext.DTO.Attributes;
    using SuperTicketApi.Domain.Seedwork;

    /// <summary>
    /// The event.
    /// </summary>
    /// <remarks>
    /// <para><c>SQL:</c>TABLE [dbo].[Events]</para>
    /// </remarks>
    [DbTable("Events")]
    public class Event : DomainEntity, IEntity<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Event"/> class.
        /// </summary>
        public Event()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Event"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="banner">
        /// The banner.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        /// <param name="startAt">
        /// The start at.
        /// </param>
        /// <param name="runTime">
        /// The run time.
        /// </param>
        /// <param name="layoutId">
        /// The layout id.
        /// </param>
        public Event(string name, string banner, string description, DateTime startAt, TimeSpan runTime, int layoutId)
        {
            this.Name = name;
            this.Banner = banner;
            this.Description = description;
            this.StartAt = startAt;
            this.RunTime = runTime;
            this.LayoutId = layoutId;
        }

        #region Implementation of IEntity<int>

        /// <inheritdoc />
        /// <remarks>
        /// <para><see cref="Event"/>Id</para>
        /// <para><c>SQL:</c> int identity primary key.</para>
        /// </remarks>
        [IdColumn(typeof(Event))]
        public int Id { get; set; }
        #endregion

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[Name] nvarchar(120) NOT NULL.</para>
        /// </remarks>
        [DbColumn("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the banner.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[Banner] nvarchar(max) NOT NULL.</para>
        /// </remarks>
        [DbColumn("Banner")]
        public string Banner { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[Description] nvarchar(max) NOT NULL.</para>
        /// </remarks>
        [DbColumn("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the start at.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[StartAt] DATETIME NOT NULL.</para>
        /// </remarks>
        [DbColumn("StartAt")]
        public DateTimeOffset StartAt { get; set; }

        /// <summary>
        /// Gets or sets the run time.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[Runtime] TIME(7) NOT NULL.</para>
        /// </remarks>
        [DbColumn("RunTime")]
        public TimeSpan RunTime { get; set; }

        /// <summary>
        /// Gets or sets the layout id.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[LayoutId] <see langword="int"/> NOT NULL.</para>
        /// </remarks>
        [DbColumn("LayoutId")]
        public int LayoutId { get; set; }
    }
}
