namespace SuperTicketApi.Domain.MainContext.Command
{
    using SuperTicketApi.Domain.MainContext.Command.CreateCommands;
    using SuperTicketApi.Domain.MainContext.Command.Delete;
    using SuperTicketApi.Domain.MainContext.Command.Update;
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


            #region Update

            this.CreateMap<Area, UpdateAreaCommand>()
              .ForMember(dto => dto.LayoutId, m => m.MapFrom(e => e.LayoutId))
              .ForMember(dto => dto.Description, m => m.MapFrom(e => e.Description))
              .ForMember(dto => dto.CoordX, m => m.MapFrom(e => e.CoordX))
              .ForMember(dto => dto.CoordY, m => m.MapFrom(e => e.CoordY))
              .ForMember(dto => dto.Command, m => m.MapFrom(e => e.Command))
              .PreserveReferences()
              .ReverseMap();

            this.CreateMap<EventArea, UpdateEventAreaCommand>()
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<Event, UpdateEventCommand>()
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<EventSeat, UpdateEventSeatCommand>()
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<Layout, UpdateLayoutCommand>()
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<Seat, UpdateSeatCommand>()
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<Venue, UpdateVenueCommand>()
                .PreserveReferences()
                .ReverseMap();

            #endregion

            #region Delete

            this.CreateMap<Area, DeleteAreaCommand>()
                .ForMember(dto => dto.Command, m => m.MapFrom(e => e.Command))
                .ForMember(dto => dto.Id, m => m.MapFrom(e => e.Id))
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<EventArea, DeleteEventAreaCommand>()

                .ForMember(dto => dto.Command, m => m.MapFrom(e => e.Command))
                .ForMember(dto => dto.Id, m => m.MapFrom(e => e.Id))
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<Event, DeleteEventCommand>()
                .ForMember(dto => dto.Command, m => m.MapFrom(e => e.Command))
                .ForMember(dto => dto.Id, m => m.MapFrom(e => e.Id))
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<EventSeat, DeleteEventSeatCommand>()
                .ForMember(dto => dto.Command, m => m.MapFrom(e => e.Command))
                .ForMember(dto => dto.Id, m => m.MapFrom(e => e.Id))
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<Layout, DeleteLayoutCommand>()
                .ForMember(dto => dto.Command, m => m.MapFrom(e => e.Command))
                .ForMember(dto => dto.Id, m => m.MapFrom(e => e.Id))
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<Seat, DeleteSeatCommand>()
                .ForMember(dto => dto.Command, m => m.MapFrom(e => e.Command))
                .ForMember(dto => dto.Id, m => m.MapFrom(e => e.Id))
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<Venue, DeleteVenueCommand>()
                .ForMember(dto => dto.Command, m => m.MapFrom(e => e.Command))
                .ForMember(dto => dto.Id, m => m.MapFrom(e => e.Id))
                .PreserveReferences()
                .ReverseMap();

            #endregion

        }
    }
}