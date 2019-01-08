namespace SuperTicketApi.ApiEndpoint.ViewModel.EventArea
{
    using System.Collections.Generic;

    using SuperTicketApi.ApiEndpoint.ViewModel.EventSeat;

    public class EventAreaViewModel : ApiViewModel
    {
        public int EventId { get; set; }
        public string Description { get; set; }
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public decimal Price { get; set; }
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
