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

    /// <summary>
    /// The get query as i enumerable handler.
    /// </summary>
    public class EnumerableAreaDomainQueryHandler : BaseQueryHandler,
        IRequestHandler<GetAreaAsIEnumerableQuery, IEnumerable<Area>>
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
        public EnumerableAreaDomainQueryHandler(
           ITabledUnitOfWork unitOfWork,
            IMediator mediatr) : base(unitOfWork, mediatr)
        {
            Log.Information($"{this.GetType().Name} was started");
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Area>> Handle(GetAreaAsIEnumerableQuery request, CancellationToken cancellationToken)
        {
            var returnList = this.UnitOfWork.AreaRepository.GetAll();
            return await Task.FromResult(returnList);
        }
    }
}
