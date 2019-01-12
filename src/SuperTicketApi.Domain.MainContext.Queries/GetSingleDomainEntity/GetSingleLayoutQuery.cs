namespace SuperTicketApi.Domain.MainContext.Queries.GetSingleDomainEntity
{
    using MediatR;

    using SuperTicketApi.Domain.MainContext.DTO.Models;

    public class GetSingleLayoutQuery : IRequest<Layout>
    {
        public int Id { get; set; }

        public GetSingleLayoutQuery( int id  )
        {
            this.Id = id;
        }
    }
}