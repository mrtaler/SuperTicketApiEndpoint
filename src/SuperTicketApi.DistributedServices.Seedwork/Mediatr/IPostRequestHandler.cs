namespace SuperTicketApi.DistributedServices.Seedwork.Mediatr
{
    public interface IPostRequestHandler<in TRequest, in TResponse>
    {
        void Handle(TRequest request, TResponse response);
    }
}