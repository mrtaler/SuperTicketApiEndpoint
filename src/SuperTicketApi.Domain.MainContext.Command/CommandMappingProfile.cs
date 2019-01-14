namespace SuperTicketApi.Domain.MainContext.Command
{
    using SuperTicketApi.Domain.MainContext.Command.CreateCommands;
    using SuperTicketApi.Domain.MainContext.Command.Delete;
    using SuperTicketApi.Domain.MainContext.Command.Update;
    using SuperTicketApi.Domain.MainContext.DTO.Models;

    public class CommandMappingProfile
          : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AreaCommandProfile"/> class.
        /// </summary>
        public CommandMappingProfile()
        {
            this.CreateMap<Area, CreateAreaDomainCommand>()
                .ForMember(dto => dto.LayoutId, m => m.MapFrom(e => e.LayoutId))
                .ForMember(dto => dto.Description, m => m.MapFrom(e => e.Description))
                .ForMember(dto => dto.CoordX, m => m.MapFrom(e => e.CoordX))
                .ForMember(dto => dto.CoordY, m => m.MapFrom(e => e.CoordY))
                .ForMember(dto => dto.Command, m => m.MapFrom(e => e.Command))
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<EventArea, CreateEventAreaDomainCommand>()
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<Event, CreateEventDomainCommand>()
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<EventSeat, CreateEventSeatDomainCommand>()
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<Layout, CreateLayoutDomainCommand>()
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<Seat, CreateSeatDomainCommand>()
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<Venue, CreateVenueDomainCommand>()
                .PreserveReferences()
                .ReverseMap();


            

            this.CreateMap<Area, UpdateAreaDomainCommand>()
              .ForMember(dto => dto.LayoutId, m => m.MapFrom(e => e.LayoutId))
              .ForMember(dto => dto.Description, m => m.MapFrom(e => e.Description))
              .ForMember(dto => dto.CoordX, m => m.MapFrom(e => e.CoordX))
              .ForMember(dto => dto.CoordY, m => m.MapFrom(e => e.CoordY))
              .ForMember(dto => dto.Command, m => m.MapFrom(e => e.Command))
              .PreserveReferences()
              .ReverseMap();

            this.CreateMap<EventArea, UpdateEventAreaDomainCommand>()
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<Event, UpdateEventDomainCommand>()
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<EventSeat, UpdateEventSeatDomainCommand>()
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<Layout, UpdateLayoutDomainCommand>()
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<Seat, UpdateSeatDomainCommand>()
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<Venue, UpdateVenueDomainCommand>()
                .PreserveReferences()
                .ReverseMap();

            #region Delete

            this.CreateMap<Area, DeleteAreaDomainCommand>()
                .ForMember(dto => dto.Command, m => m.MapFrom(e => e.Command))
                .ForMember(dto => dto.Id, m => m.MapFrom(e => e.Id))
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<EventArea, DeleteEventAreaDomainCommand>()

                .ForMember(dto => dto.Command, m => m.MapFrom(e => e.Command))
                .ForMember(dto => dto.Id, m => m.MapFrom(e => e.Id))
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<Event, DeleteEventDomainCommand>()
                .ForMember(dto => dto.Command, m => m.MapFrom(e => e.Command))
                .ForMember(dto => dto.Id, m => m.MapFrom(e => e.Id))
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<EventSeat, DeleteEventSeatDomainCommand>()
                .ForMember(dto => dto.Command, m => m.MapFrom(e => e.Command))
                .ForMember(dto => dto.Id, m => m.MapFrom(e => e.Id))
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<Layout, DeleteLayoutDomainCommand>()
                .ForMember(dto => dto.Command, m => m.MapFrom(e => e.Command))
                .ForMember(dto => dto.Id, m => m.MapFrom(e => e.Id))
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<Seat, DeleteSeatDomainCommand>()
                .ForMember(dto => dto.Command, m => m.MapFrom(e => e.Command))
                .ForMember(dto => dto.Id, m => m.MapFrom(e => e.Id))
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<Venue, DeleteVenueDomainCommand>()
                .ForMember(dto => dto.Command, m => m.MapFrom(e => e.Command))
                .ForMember(dto => dto.Id, m => m.MapFrom(e => e.Id))
                .PreserveReferences()
                .ReverseMap();

            #endregion
        }
    }
}