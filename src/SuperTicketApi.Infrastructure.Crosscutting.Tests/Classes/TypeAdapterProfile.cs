namespace SuperTicketApi.Infrastructure.Crosscutting.Tests.Classes
{
    using AutoMapper;

    public class TypeAdapterProfile : Profile
    {
        public TypeAdapterProfile()
        {
            CreateMap<Blog, BlogDTO>()
                .ForMember(dto => dto.BlogId, m => m.MapFrom(e => e.BlogId))
                .ForMember(dto => dto.Name, m => m.MapFrom(e => e.Name))
                .ForMember(dto => dto.Url, m => m.MapFrom(e => e.Url))
                .ForMember(dto => dto.Rating, m => m.MapFrom(e => e.Rating))
                .PreserveReferences()
                ;
        }
    }
}
