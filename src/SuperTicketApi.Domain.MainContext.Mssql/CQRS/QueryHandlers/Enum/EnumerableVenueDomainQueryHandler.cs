namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.QueryHandlers
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Serilog;

    using SuperTicketApi.Domain.MainContext.DTO;
    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.MainContext.Queries.GetListOfDomainEntity;

    public class EnumerableVenueDomainQueryHandler : BaseQueryHandler,
    IRequestHandler<GetVenueAsIEnumerableQuery, IEnumerable<Venue>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetQueryAsIEnumerableQueryHandler"/> class.
        /// </summary>
        /// <param name="unitOfWork">
        /// The unit Of Work.
        /// </param>
        /// <param name="mediatr">
        /// The <paramref name="mediatr"/>.
        /// </param>
        public EnumerableVenueDomainQueryHandler(
           ITabledUnitOfWork unitOfWork,
            IMediator mediatr) : base(unitOfWork, mediatr)
        {
            Log.Information($"{this.GetType().Name} was started");
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Venue>> Handle(GetVenueAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
            var returnList = this.UnitOfWork.VenueRepository.GetAll();
            return await Task.FromResult(returnList);
        }
    }

}
