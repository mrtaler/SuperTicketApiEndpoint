namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.QueryHandlers
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Serilog;

    using SuperTicketApi.Domain.MainContext.DTO;
    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.MainContext.Queries.GetSingleDomainEntity;

    /// <summary>
    /// The get query as i enumerable handler.
    /// </summary>
    public class SingleAreaDomainQueryHandler : BaseQueryHandler,
        IRequestHandler<GetSingleAreaQuery, Area>
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
        public SingleAreaDomainQueryHandler(ITabledUnitOfWork unitOfWork, IMediator mediatr) : base(unitOfWork, mediatr)
        {
            Log.Information($"{this.GetType().Name} was started");
        }

        /// <inheritdoc />
        public async Task<Area> Handle(GetSingleAreaQuery request, CancellationToken cancellationToken)
        {
            var retVal = this.UnitOfWork.AreaRepository.GetById(request.Id);
            return await Task.FromResult(retVal);
        }
    }
}
