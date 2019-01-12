namespace SuperTicketApi.Domain.MainContext.Queries.GetSingleDomainEntity
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    public class GetSingleEventSeatQuery : IRequest<EventSeat>
    {
        public int Id { get; set; }

        public GetSingleEventSeatQuery( int id  )
        {
            this.Id = id;
        }
    }
}