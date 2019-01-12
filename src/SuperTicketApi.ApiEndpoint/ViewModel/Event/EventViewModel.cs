namespace SuperTicketApi.ApiEndpoint.ViewModel.Event
{
    using System;
    using System.Collections.Generic;

    using SuperTicketApi.ApiEndpoint.ViewModel.EventArea;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="SuperTicketApi.ApiEndpoint.ViewModel.ApiViewModel" />
    public class EventViewModel : ApiViewModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the banner.
        /// </summary>
        /// <value>
        /// The banner.
        /// </value>
        public string Banner { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the start at.
        /// </summary>
        /// <value>
        /// The start at.
        /// </value>
        public DateTime StartAt { get; set; }

        /// <summary>
        /// Gets or sets the run time.
        /// </summary>
        /// <value>
        /// The run time.
        /// </value>
        public TimeSpan RunTime { get; set; }

        /// <summary>
        /// Gets or sets the layout identifier.
        /// </summary>
        /// <value>
        /// The layout identifier.
        /// </value>
        public int LayoutID { get; set; }

        /// <summary>
        /// Gets or sets the event area.
        /// </summary>
        /// <value>
        /// The event area.
        /// </value>
        public List<EventAreaViewModel> EventArea { get; set; }
    }

    /*
      Area
    EventArea
    Event
    EventSeat
    Layout
    Seat
    Venue
    */
}
