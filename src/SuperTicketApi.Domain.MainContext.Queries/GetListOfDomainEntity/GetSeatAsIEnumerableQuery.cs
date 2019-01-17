namespace SuperTicketApi.Domain.MainContext.Queries.GetListOfDomainEntity
{
    using System.Collections.Generic;

    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The get seat as i enumerable query.
    /// </summary>
    public class GetSeatAsIEnumerableQuery : IRequest<IEnumerable<Seat>>
    {
    }
}