namespace SuperTicketApi.Domain.MainContext.Queries.GetSingleDomainEntity
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    public class GetSingleEventQuery : IRequest<Event>
    {
        public int Id { get; set; }

        public GetSingleEventQuery( int id  )
        {
            Id = id;
        }
    }
}