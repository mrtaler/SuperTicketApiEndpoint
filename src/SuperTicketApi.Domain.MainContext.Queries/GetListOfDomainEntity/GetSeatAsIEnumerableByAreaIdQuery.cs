namespace SuperTicketApi.Domain.MainContext.Queries.GetListOfDomainEntity
{
    using System.Collections.Generic;

    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    public class GetSeatAsIEnumerableByAreaIdQuery : IRequest<IEnumerable<Seat>>
    {
        public int AreaId { get; set; }
        public GetSeatAsIEnumerableByAreaIdQuery(int areaId)
        {
            AreaId = areaId;
        }
    }
}