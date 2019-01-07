using System.Collections.Generic;

namespace SuperTicketApi.ApiEndpoint.ViewModel
{
    public class VenueViewModel :ApiViewModel
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public List<LayoutViewModel> Layout { get; set; }
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
