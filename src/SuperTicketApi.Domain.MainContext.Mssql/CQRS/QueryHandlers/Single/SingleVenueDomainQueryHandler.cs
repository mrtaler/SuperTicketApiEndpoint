namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.QueryHandlers
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Serilog;

    using SuperTicketApi.Domain.MainContext.DTO;
    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.MainContext.Queries.GetSingleDomainEntity;

    public class SingleVenueDomainQueryHandler : BaseQueryHandler,
    IRequestHandler<GetSingleVenueQuery, Venue>
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
        public SingleVenueDomainQueryHandler(ITabledUnitOfWork unitOfWork, IMediator mediatr) : base(unitOfWork, mediatr)
        {
            Log.Information($"{this.GetType().Name} was started");
        }

        /// <inheritdoc />
        public async Task<Venue> Handle(GetSingleVenueQuery request, CancellationToken cancellationToken)
        {
            var retVal = this.UnitOfWork.VenueRepository.GetById(request.Id);
            return await Task.FromResult(retVal);
        }
    }
}
