namespace SuperTicketApi.Domain.MainContext.Queries.GetSingleDomainEntity
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    public class GetSingleSeatQuery : IRequest<Seat>
    {
        public int Id { get; set; }

        public GetSingleSeatQuery( int id  )
        {
            this.Id = id;
        }
    }
}