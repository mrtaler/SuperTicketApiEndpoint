﻿namespace SuperTicketApi.Domain.MainContext.Queries.GetSingleDomainEntity
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    public class GetSingleVenueQuery : IRequest<Venue>
    {
    }
}