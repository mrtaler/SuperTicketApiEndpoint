namespace SuperTicketApi.DistributedServices.Seedwork.Mediatr
{
    public interface IPreRequestHandler<in TRequest>
    {
        void Handle(TRequest request);
    }
}