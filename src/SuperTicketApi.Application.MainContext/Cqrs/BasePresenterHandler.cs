namespace SuperTicketApi.Application.MainContext.Cqrs
{
    using MediatR;

    using Serilog;

    /// <summary>
    /// base query command Handler
    /// </summary>
    public class BaseApplicationHandler
    {
        protected readonly IMediator Mediatr;

        public BaseApplicationHandler( IMediator mediatr)
        {
            this.Mediatr = mediatr;
            Log.Information($"{this.GetType().Name} was started");
        }
    }
}
