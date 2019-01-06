﻿namespace SuperTicketApi.Domain.MainContext.Queries.GetListOfDomainEntity
{
    using System.Collections.Generic;

    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    public class GetAreaAsIEnumerableQuery : IRequest<IEnumerable<Area>>
    {
    }
}