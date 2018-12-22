namespace SuperTicketApi.Application.BoundedContext.DTO
{
    using SuperTicketApi.Domain.MainContext.ItemsContext.Aggregates;

    public class ItemProfile
         : AutoMapper.Profile
    {
        public ItemProfile()
        {
            // bankAccount => BankAccountDTO
            this.CreateMap<Item, ItemDto>()
                .ForMember(dto => dto.ItemId, mc => mc.MapFrom(e => e.Id))
                .PreserveReferences();
        }
    }
}