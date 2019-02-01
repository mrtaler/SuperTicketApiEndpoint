namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.QueryHandlers
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Serilog;

    using SuperTicketApi.Domain.MainContext.DTO;
    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.MainContext.Queries.GetSingleDomainEntity;

    public class SingleEventAreaDomainQueryHandler : BaseQueryHandler,
    IRequestHandler<GetSingleEventAreaQuery, EventArea>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetQueryAsSingleHandler"/> class.
        /// </summary>
        /// <param name="factory">
        /// The factory.
        /// </param>
        /// <param name="mediatr">
        /// The mediatr.
        /// </param>
        public SingleEventAreaDomainQueryHandler(ITabledUnitOfWork unitOfWork, IMediator mediatr) : base(unitOfWork, mediatr)
        {
            Log.Information($"{this.GetType().Name} was started");
        }

        /// <inheritdoc />
        public async Task<EventArea> Handle(GetSingleEventAreaQuery request, CancellationToken cancellationToken)
        {
            var retVal = this.UnitOfWork.EventAreaRepository.GetById(request.Id);
            return await Task.FromResult(retVal);
        }
    }
}
