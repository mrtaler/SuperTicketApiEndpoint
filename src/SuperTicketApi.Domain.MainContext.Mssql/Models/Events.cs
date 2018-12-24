namespace SuperTicketApi.Domain.MainContext.Mssql.Models
{
    using System;

    using SuperTicketApi.Domain.Seedwork;

    public class Events : Entity, IEntity<int>
    {
        /// <summary>
        /// Gets or sets the id.  [EventId] int primary key identity,
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.    [Name] nvarchar(120) NOT NULL,
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the banner. [Banner] nvarchar(max) NOT NULL,
        /// </summary>
        public string Banner { get; set; }

        /// <summary>
        /// Gets or sets the description. [Description] nvarchar(max) NOT NULL,
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the start at.   [StartAt] DATETIMEOFFSET NOT NULL,
        /// </summary>
        public DateTimeOffset StartAt { get; set; }

        /// <summary>
        /// Gets or sets the runtime. [Runtime] TIME(7) NOT NULL,
        /// </summary>
        public TimeSpan Runtime { get; set; }

        /// <summary>
        /// Gets or sets the fk_ event place id. [Fk_EventPlaceId] int NOT NULL, 
        /// </summary>
        public int Fk_EventPlaceId { get; set; }

        /// <summary>
        /// Gets or sets the max seats.  [MaxSeats] INT NOT NULL,
        /// </summary>
        public int MaxSeats { get; set; }
    }
}