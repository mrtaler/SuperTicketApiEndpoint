namespace SuperTicketApi.Application.MainContext.Cqrs
{
    using MediatR;

    using Serilog;

    /// <summary>
    /// base query command Handler
    /// </summary>
    public class BaseApplicationHandler
    {
        protected readonly IMediator mediatr;

        public BaseApplicationHandler( IMediator mediatr)
        {
            this.mediatr = mediatr;
            Log.Information($"{this.GetType().Name} was started");
        }
    }
}
