namespace SuperTicketApi.ApiEndpoint.ViewModel.EventArea
{
    using System.Collections.Generic;

    using SuperTicketApi.ApiEndpoint.ViewModel.EventSeat;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="SuperTicketApi.ApiEndpoint.ViewModel.ApiViewModel" />
    public class EventAreaViewModel : ApiViewModel
    {
        /// <summary>
        /// Gets or sets the event identifier.
        /// </summary>
        /// <value>
        /// The event identifier.
        /// </value>
        public int EventId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the coord x.
        /// </summary>
        /// <value>
        /// The coord x.
        /// </value>
        public int CoordX { get; set; }

        /// <summary>
        /// Gets or sets the coord y.
        /// </summary>
        /// <value>
        /// The coord y.
        /// </value>
        public int CoordY { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the eventseat.
        /// </summary>
        /// <value>
        /// The eventseat.
        /// </value>
        public List<EventSeatViewModel> Eventseat { get; set; }
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
