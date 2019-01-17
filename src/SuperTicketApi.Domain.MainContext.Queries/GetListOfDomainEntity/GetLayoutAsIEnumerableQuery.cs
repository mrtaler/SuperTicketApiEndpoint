namespace SuperTicketApi.Domain.MainContext.Queries.GetListOfDomainEntity
{
    using System.Collections.Generic;

    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The get layout as i enumerable query.
    /// </summary>
    public class GetLayoutAsIEnumerableQuery : IRequest<IEnumerable<Layout>>
    {
    }
}