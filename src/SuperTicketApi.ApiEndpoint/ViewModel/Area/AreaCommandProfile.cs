namespace SuperTicketApi.ApiEndpoint.ViewModel.Area
{
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Area;

    /// <summary>
    /// The area command profile.
    /// </summary>
    public class AreaCommandProfile
        : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AreaCommandProfile"/> class.
        /// </summary>
        public AreaCommandProfile()
        {
            this.CreateMap<CreateAreaViewModel, PresenterCreateAreaCommand>()
                .ForMember(dto => dto.LayoutId, m => m.MapFrom(e => e.LayoutId))
                .ForMember(dto => dto.Description, m => m.MapFrom(e => e.Description))
                .ForMember(dto => dto.CoordX, m => m.MapFrom(e => e.CoordX))
                .ForMember(dto => dto.CoordY, m => m.MapFrom(e => e.CoordY))

                .PreserveReferences()
                .ReverseMap();
        }
    }
}