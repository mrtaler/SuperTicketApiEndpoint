namespace SuperTicketApi.Application.BoundedContext.DTO.Dto
{
    using System;

    /// <summary>
    /// The event.
    /// </summary>
    public class EventDto : IBusinessDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventDto"/> class.
        /// </summary>
        public EventDto()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventDto"/> class. 
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
        public EventDto(string name, string banner, string description, DateTime startAt, TimeSpan runTime, int layoutId)
        {
            this.Name = name;
            this.Banner = banner;
            this.Description = description;
            this.StartAt = startAt;
            this.RunTime = runTime;
            this.LayoutId = layoutId;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the banner.
        /// </summary>
        public string Banner { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the start at.
        /// </summary>
        public DateTime StartAt { get; set; }

        /// <summary>
        /// Gets or sets the run time.
        /// </summary>
        public TimeSpan RunTime { get; set; }

        /// <summary>
        /// Gets or sets the layout id.
        /// </summary>
        public int LayoutId { get; set; }
    }
}
