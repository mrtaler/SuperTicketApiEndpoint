namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.QueryHandlers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Serilog;

    using SuperTicketApi.Domain.MainContext.DTO;
    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.MainContext.Queries.GetListOfDomainEntity;
    using SuperTicketApi.Domain.Seedwork.Specifications.Specifications;

    /// <inheritdoc cref="BaseQueryHandler" />
    public class EnumerableSeatDomainQueryHandler : BaseQueryHandler,
    IRequestHandler<GetSeatAsIEnumerableQuery, IEnumerable<Seat>>,
    IRequestHandler<GetSeatAsIEnumerableByAreaIdQuery, IEnumerable<Seat>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerableSeatDomainQueryHandler"/> class. 
        /// </summary>
        /// <param name="unitOfWork">
        /// The unit Of Work.
        /// </param>
        /// <param name="mediatr">
        /// The <paramref name="mediatr"/>.
        /// </param>
        public EnumerableSeatDomainQueryHandler(
           ITabledUnitOfWork unitOfWork,
            IMediator mediatr) : base(unitOfWork, mediatr)
        {
            Log.Information($"{this.GetType().Name} was started");
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Seat>> Handle(GetSeatAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
            var returnList = this.UnitOfWork.SeatRepository.GetAll();
            return await Task.FromResult(returnList);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Seat>> Handle(GetSeatAsIEnumerableByAreaIdQuery request, CancellationToken cancellationToken)
        {
            var returnList = this.UnitOfWork.SeatRepository.GetAll();
            var ret = returnList.Where(p => p.AreaId == request.AreaId);
            return await Task.FromResult(ret);
        }
    }
}
