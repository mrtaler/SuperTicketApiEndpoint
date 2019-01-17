namespace SuperTicketApi.Domain.MainContext.Queries.GetListOfDomainEntity
{
    using System.Collections.Generic;

    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The get event seat as i enumerable query.
    /// </summary>
    public class GetEventSeatAsIEnumerableQuery : IRequest<IEnumerable<EventSeat>>
    {
    }
}