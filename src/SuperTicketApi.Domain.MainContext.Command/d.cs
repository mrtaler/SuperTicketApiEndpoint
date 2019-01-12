namespace SuperTicketApi.Domain.MainContext.Command
{
    using SuperTicketApi.Domain.MainContext.Command.CreateCommands;
    using SuperTicketApi.Domain.MainContext.DTO.Models;

    public class CommandProfile
          : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AreaCommandProfile"/> class.
        /// </summary>
        public CommandProfile()
        {
            this.CreateMap<Area, CreateAreaCommand>()
                .ForMember(dto => dto.LayoutId, m => m.MapFrom(e => e.LayoutId))
                .ForMember(dto => dto.Description, m => m.MapFrom(e => e.Description))
                .ForMember(dto => dto.CoordX, m => m.MapFrom(e => e.CoordX))
                .ForMember(dto => dto.CoordY, m => m.MapFrom(e => e.CoordY))
                .ForMember(dto => dto.Command, m => m.MapFrom(e => e.Command))
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<EventArea, CreateEventAreaCommand>()
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<Event, CreateEventCommand>()
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<EventSeat, CreateEventSeatCommand>()
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<Layout, CreateLayoutCommand>()
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<Seat, CreateSeatCommand>()
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<Venue, CreateVenueCommand>()
                .PreserveReferences()
                .ReverseMap();


        }
    }
}