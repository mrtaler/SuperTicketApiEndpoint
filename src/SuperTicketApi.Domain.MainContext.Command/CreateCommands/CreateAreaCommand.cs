using MediatR;
using SuperTicketApi.Domain.MainContext.DTO.Attributes;
using System;

namespace SuperTicketApi.Domain.MainContext.Command.CreateCommands
{
    public class CreateAreaCommand : IRequest<DalCommandResponse>
    {
        /// <summary>
        /// Gets or sets the layout id.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[LayoutId] <see langword="int"/> NOT NULL.</para>
        /// </remarks>
        [DbColumn("LayoutId")]
        public int LayoutId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[Description] nvarchar(200) NOT NULL.</para>
        /// </remarks>
        [DbColumn("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the CoordX.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[CoordX] <see langword="int"/> NOT NULL.</para>
        /// </remarks>
        [DbColumn("CoordX")]
        public int CoordX { get; set; }

        /// <summary>
        /// Gets or sets the CoordY.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[CoordY] <see langword="int"/> NOT NULL.</para>
        /// </remarks>
        [DbColumn("CoordY")]
        public int CoordY { get; set; }
        public string Command => CreateSpCommandPattern.CreateArea;
    }
    public class CreateEventAreaCommand : IRequest<DalCommandResponse>
    {
        /// <summary>
        /// Gets or sets the event id.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[EventId] <see langword="int"/> NOT NULL.</para>
        /// </remarks>
        [DbColumn("EventId")]
        public int EventId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[Description] nvarchar(200) NOT NULL.</para>
        /// </remarks>
        [DbColumn("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the coordX.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[CoordX] <see langword="int"/> NOT NULL.</para>
        /// </remarks>
        [DbColumn("CoordX")]
        public int CoordX { get; set; }

        /// <summary>
        /// Gets or sets the coordY.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[CoordY] <see langword="int"/> NOT NULL.</para>
        /// </remarks>
        [DbColumn("CoordY")]
        public int CoordY { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[Price] <see langword="decimal"/>(18, 2) NOT NULL.</para>
        /// </remarks>
        [DbColumn("Price")]
        public decimal Price { get; set; }
        public string Command => CreateSpCommandPattern.CreateEventArea;
    }
    public class CreateEventCommand : IRequest<DalCommandResponse>
    {
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
        public DateTime StartAt { get; set; }

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
        public string Command => CreateSpCommandPattern.CreateEvent;
    }
    public class CreateEventSeatCommand : IRequest<DalCommandResponse>
    { /// <summary>
      /// Gets or sets the event areas id.
      /// </summary>
      /// <remarks>
      /// <para><c>SQL:</c>[EventAreaId] <see langword="int"/> NOT NULL,.</para>
      /// </remarks>
        [DbColumn("EventAreaId")]
        public int EventAreaId { get; set; }

        /// <summary>
        /// Gets or sets the row.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[Row] <see langword="int"/> NOT NULL.</para>
        /// </remarks>
        [DbColumn("Row")]
        public int Row { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[Number] <see langword="int"/> NOT NULL.</para>
        /// </remarks>
        [DbColumn("Number")]
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[State] <see langword="int"/> NOT NULL.</para>
        /// </remarks>
        [DbColumn("State")]
        public int State { get; set; }
        public string Command => CreateSpCommandPattern.CreateEventSeat;
    }
    public class CreateLayoutCommand : IRequest<DalCommandResponse>
    {
        /// <summary>
        /// Gets or sets the venue id.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[VenueId] <see langword="int"/> NOT NULL.</para>
        /// </remarks>
        [DbColumn("VenueId")]
        public int VenueId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[Description] nvarchar(120) NOT NULL.</para>
        /// </remarks>
        [DbColumn("Description")]
        public string Description { get; set; }
        public string Command => CreateSpCommandPattern.CreateLayout;
    }
    public class CreateSeatCommand : IRequest<DalCommandResponse>
    {
        /// <summary>
        /// Gets or sets the area id.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[AreaId] <see langword="int"/> NOT NULL</para>
        /// </remarks>
        [DbColumn("AreaId")]
        public int AreaId { get; set; }

        /// <summary>
        /// Gets or sets the row.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[Row] <see langword="int"/> NOT NULL</para>
        /// </remarks>
        [DbColumn("Row")]
        public int Row { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[Number] <see langword="int"/> NOT NULL</para>
        /// </remarks>
        [DbColumn("Number")]
        public int Number { get; set; }
        public string Command => CreateSpCommandPattern.CreateSeat;
    }
    public class CreateVenueCommand : IRequest<DalCommandResponse>
    {
        /// <summary>
       /// Gets or sets the description.
       /// </summary>
       /// <remarks>
       /// <para><c>SQL:</c>[Description] nvarchar(120) NOT NULL.</para>
       /// </remarks>
        [DbColumn("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[Address] nvarchar(200) NOT NULL.</para>
        /// </remarks>
        [DbColumn("Address")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <remarks>
        /// <para><c>SQL:</c>[Phone] nvarchar(30).</para>
        /// </remarks>
        [DbColumn("Phone")]
        public string Phone { get; set; }
        public string Command => CreateSpCommandPattern.CreateVenue;
    }
}