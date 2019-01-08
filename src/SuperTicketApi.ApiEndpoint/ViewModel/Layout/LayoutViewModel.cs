namespace SuperTicketApi.ApiEndpoint.ViewModel.Layout
{
    using System.Collections.Generic;

    using SuperTicketApi.ApiEndpoint.ViewModel.Area;
    using SuperTicketApi.ApiEndpoint.ViewModel.Event;

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
