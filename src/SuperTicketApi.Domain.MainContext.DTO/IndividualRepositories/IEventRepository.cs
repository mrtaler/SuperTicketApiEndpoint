namespace SuperTicketApi.Domain.MainContext.DTO.IndividualRepositories
{
    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.Seedwork.Repository;

    /// <summary>
    /// The EventRepository interface.
    /// </summary>
    public interface IEventRepository: IRepository<Event>
    {

    }
}