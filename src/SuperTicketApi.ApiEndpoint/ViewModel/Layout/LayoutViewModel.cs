namespace SuperTicketApi.ApiEndpoint.ViewModel.Layout
{
    using System.Collections.Generic;

    using SuperTicketApi.ApiEndpoint.ViewModel.Area;
    using SuperTicketApi.ApiEndpoint.ViewModel.Event;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="SuperTicketApi.ApiEndpoint.ViewModel.ApiViewModel" />
    public class LayoutViewModel : ApiViewModel
    {
        /// <summary>
        /// Gets or sets the venue identifier.
        /// </summary>
        /// <value>
        /// The venue identifier.
        /// </value>
        public int VenueId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the area.
        /// </summary>
        /// <value>
        /// The area.
        /// </value>
        public List<AreaViewModel> Area { get; set; }

        /// <summary>
        /// Gets or sets the event.
        /// </summary>
        /// <value>
        /// The event.
        /// </value>
        public List<EventViewModel> Event { get; set; }
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
