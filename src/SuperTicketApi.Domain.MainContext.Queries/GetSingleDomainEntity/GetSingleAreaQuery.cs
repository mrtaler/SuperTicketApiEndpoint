namespace SuperTicketApi.Domain.MainContext.Queries.GetSingleDomainEntity
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    public class GetSingleAreaQuery : IRequest<Area>
    {
        public int Id { get; set; }

        public GetSingleAreaQuery( int id  )
        {
            Id = id;
        }
    }
}
