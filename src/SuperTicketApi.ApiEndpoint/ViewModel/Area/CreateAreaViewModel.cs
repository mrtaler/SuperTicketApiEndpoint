namespace SuperTicketApi.ApiEndpoint.ViewModel.Area
{
    public class CreateAreaViewModel:ApiViewModel
    {
        public int LayoutId { get; set; }
        public string Description { get; set; }
        public int CoordX { get; set; }
        public int CoordY { get; set; }
    }
}
