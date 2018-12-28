namespace SuperTicketApi.Domain.MainContext.Mssql.Models
{
    using System;

    using SuperTicketApi.Domain.MainContext.Mssql.Attributes;
    using SuperTicketApi.Domain.Seedwork;
    [DbTable("Events")]
    public class Events : Entity, IEntity<int>
    {
        /// <summary>
        /// Gets or sets the id.  [EventId] int primary key identity,
        /// </summary>
        [DbColumn("EventId")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.    [Name] nvarchar(120) NOT NULL,
        /// </summary>
        [DbColumn("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the banner. [Banner] nvarchar(max) NOT NULL,
        /// </summary>
        [DbColumn("Banner")]
        public string Banner { get; set; }

        /// <summary>
        /// Gets or sets the description. [Description] nvarchar(max) NOT NULL,
        /// </summary>
        [DbColumn("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the start at.   [StartAt] DATETIMEOFFSET NOT NULL,
        /// </summary>
        [DbColumn("StartAt")]
        public DateTimeOffset StartAt { get; set; }

        /// <summary>
        /// Gets or sets the runtime. [Runtime] TIME(7) NOT NULL,
        /// </summary>
        [DbColumn("Runtime")]
        public TimeSpan Runtime { get; set; }

        /// <summary>
        /// Gets or sets the fk_ event place id. [Fk_EventPlaceId] int NOT NULL, 
        /// </summary>
        [DbColumn("Fk_EventPlaceId")]
        public int Fk_EventPlaceId { get; set; }

        /// <summary>
        /// Gets or sets the max seats.  [MaxSeats] INT NOT NULL,
        /// </summary>
        [DbColumn("MaxSeats")]
        public int MaxSeats { get; set; }
    }
}