namespace SuperTicketApi.ApiEndpoint.ViewModel.Event
{
    using System;
    using System.Collections.Generic;

    using SuperTicketApi.ApiEndpoint.ViewModel.EventArea;

    public class EventViewModel : ApiViewModel
    {
        public string Name { get; set; }
        public string Banner { get; set; }
        public string Description { get; set; }
        public DateTime StartAt { get; set; }
        public TimeSpan RunTime { get; set; }
        public int LayoutID { get; set; }
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
