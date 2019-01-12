namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS
{
    using System.Data;

    using MediatR;

    using Serilog;

    using SuperTicketApi.Domain.MainContext.DTO;

    /// <summary>
    /// base query command Handler
    /// </summary>
    public class BaseHandler
    {
        /// <summary>
        /// The uow.
        /// </summary>
        protected readonly ITabledUnitOfWork UnitOfWork;

        /// <summary>
        /// The mediatr.
        /// </summary>
        protected readonly IMediator Mediatr;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseHandler"/> class.
        /// </summary>
        /// <param name="factory">
        /// The factory.
        /// </param>
        /// <param name="mediatr">
        /// The mediatr.
        /// </param>
        public BaseHandler(ITabledUnitOfWork unitOfWork, IMediator mediatr)
        {
            this.UnitOfWork = unitOfWork;
            this.Mediatr = mediatr;
            Log.Information($"{this.GetType().Name} was started");
        }
    }
}
