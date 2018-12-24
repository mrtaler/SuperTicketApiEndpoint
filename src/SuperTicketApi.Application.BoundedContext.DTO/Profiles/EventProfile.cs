namespace SuperTicketApi.Application.BoundedContext.DTO.Profiles
{
    using SuperTicketApi.Application.BoundedContext.DTO.Dto;
    using SuperTicketApi.Domain.MainContext.Mssql.Models;

    public class EventProfile
         : AutoMapper.Profile
    {
        public EventProfile()
        {
            // bankAccount => BankAccountDTO
            this.CreateMap<Events, EventDto>()
                .PreserveReferences();
        }
    }
}