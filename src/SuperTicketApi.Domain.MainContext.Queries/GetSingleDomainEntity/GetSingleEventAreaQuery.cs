namespace SuperTicketApi.Domain.MainContext.Queries.GetSingleDomainEntity
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    public class GetSingleEventAreaQuery : IRequest<EventArea>
    {
        public int Id { get; set; }

        public GetSingleEventAreaQuery( int id  )
        {
            Id = id;
        }
    }
}