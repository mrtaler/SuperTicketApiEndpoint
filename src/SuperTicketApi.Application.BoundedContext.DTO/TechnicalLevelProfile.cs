namespace SuperTicketApi.Application.BoundedContext.DTO
{
    using SuperTicketApi.Domain.MainContext.ItemsContext.Aggregates;

    public class TechnicalLevelProfile
        : AutoMapper.Profile
    {
        public TechnicalLevelProfile()
        {
            // bankAccount => BankAccountDTO
            this.CreateMap<TechnicalLevel, TechnicalLevelDto>()

                // .ForMember(dto => dto.ItemId, mc => mc.MapFrom(e => e.Id))
                .PreserveReferences();
        }
    }
}
