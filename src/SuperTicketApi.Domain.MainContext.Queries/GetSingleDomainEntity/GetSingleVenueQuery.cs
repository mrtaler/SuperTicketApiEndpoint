namespace SuperTicketApi.Domain.MainContext.Queries.GetSingleDomainEntity
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    public class GetSingleVenueQuery : IRequest<Venue>
    {
        public int Id { get; set; }

        public GetSingleVenueQuery( int id  )
        {
            Id = id;
        }
    }
}