using System.Collections.Generic;

namespace SuperTicketApi.ApiEndpoint.ViewModel
{
    public class LayoutViewModel : ApiViewModel
    {
        public int VenueId { get; set; }
        public string Description { get; set; }
        public List<AreaViewModel> Area { get; set; }
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
