using System.Collections.Generic;

namespace SuperTicketApi.ApiEndpoint.ViewModel
{
    public class AreaViewModel : ApiViewModel
    {
        public int LayoutId { get; set; }
        public string Description { get; set; }
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public List<SeatViewModel> Seat { get; set; }
    }

}
