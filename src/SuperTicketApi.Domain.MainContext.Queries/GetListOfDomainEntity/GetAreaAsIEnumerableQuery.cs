namespace SuperTicketApi.Domain.MainContext.Queries.GetListOfDomainEntity
{
    using System.Collections.Generic;

    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The get area as i enumerable query.
    /// </summary>
    public class GetAreaAsIEnumerableQuery : IRequest<IEnumerable<Area>>
    {
    }
}
