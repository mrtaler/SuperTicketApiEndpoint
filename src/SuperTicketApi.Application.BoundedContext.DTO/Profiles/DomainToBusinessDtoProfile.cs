namespace SuperTicketApi.Application.BoundedContext.DTO.Profiles
{
    using SuperTicketApi.Application.BoundedContext.DTO.Dto;
    using SuperTicketApi.Domain.MainContext.DTO.Models;

    /// <summary>
    /// The area dto profile.
    /// </summary>
    public class DomainToBusinessDtoProfile
        : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainToBusinessDtoProfile"/> class.
        /// </summary>
        public DomainToBusinessDtoProfile()
        {
            // Domain command response => Area DTO
            this.CreateMap<object, AreaDto>()
                .ForMember(dto => dto.Id, m => m.MapFrom(e => (e as Area).Id))
                .ForMember(dto => dto.LayoutId, m => m.MapFrom(e => (e as Area).LayoutId))
                .ForMember(dto => dto.Description, m => m.MapFrom(e => (e as Area).Description))
                .ForMember(dto => dto.CoordX, m => m.MapFrom(e => (e as Area).CoordX))
                .ForMember(dto => dto.CoordY, m => m.MapFrom(e => (e as Area).CoordY))
                .PreserveReferences();

            // Domain command response => EventArea Dto
            this.CreateMap<object, EventAreaDto>()
                .ForMember(dto => dto.Id, m => m.MapFrom(e => (e as EventArea).Id))
                .ForMember(dto => dto.EventId, m => m.MapFrom(e => (e as EventArea).EventId))
                .ForMember(dto => dto.Description, m => m.MapFrom(e => (e as EventArea).Description))
                .ForMember(dto => dto.CoordX, m => m.MapFrom(e => (e as EventArea).CoordX))
                .ForMember(dto => dto.CoordY, m => m.MapFrom(e => (e as EventArea).CoordY))
                .ForMember(dto => dto.Price, m => m.MapFrom(e => (e as EventArea).Price))
                .PreserveReferences();

            // Domain command response => Event Dto
            this.CreateMap<object, EventDto>()
                .ForMember(dto => dto.Id, m => m.MapFrom(e => (e as Event).Id))
                .ForMember(dto => dto.Name, m => m.MapFrom(e => (e as Event).Name))
                .ForMember(dto => dto.Banner, m => m.MapFrom(e => (e as Event).Banner))
                .ForMember(dto => dto.Description, m => m.MapFrom(e => (e as Event).Description))
                .ForMember(dto => dto.StartAt, m => m.MapFrom(e => (e as Event).StartAt))
                .ForMember(dto => dto.RunTime, m => m.MapFrom(e => (e as Event).RunTime))
                .ForMember(dto => dto.LayoutId, m => m.MapFrom(e => (e as Event).LayoutId))
                .PreserveReferences();

            // Domain command response => EventSeat Dto
            this.CreateMap<object, EventSeatDto>()
               .ForMember(dto => dto.Id, m => m.MapFrom(e => (e as EventSeat).Id))
               .ForMember(dto => dto.EventAreaId, m => m.MapFrom(e => (e as EventSeat).EventAreaId))
               .ForMember(dto => dto.Row, m => m.MapFrom(e => (e as EventSeat).Row))
               .ForMember(dto => dto.Number, m => m.MapFrom(e => (e as EventSeat).Number))
               .ForMember(dto => dto.State, m => m.MapFrom(e => (e as EventSeat).State))
               .PreserveReferences();

            // Domain command response => EventSeat Dto
            this.CreateMap<object, LayoutDto>()
               .ForMember(dto => dto.Id, m => m.MapFrom(e => (e as Layout).Id))
               .ForMember(dto => dto.VenueId, m => m.MapFrom(e => (e as Layout).VenueId))
               .ForMember(dto => dto.Description, m => m.MapFrom(e => (e as Layout).Description))
               .PreserveReferences();

            // Domain command response => Seat Dto
            this.CreateMap<object, SeatDto>()
               .ForMember(dto => dto.Id, m => m.MapFrom(e => (e as Seat).Id))
               .ForMember(dto => dto.AreaId, m => m.MapFrom(e => (e as Seat).AreaId))
               .ForMember(dto => dto.Row, m => m.MapFrom(e => (e as Seat).Row))
               .ForMember(dto => dto.Number, m => m.MapFrom(e => (e as Seat).Number))
               .PreserveReferences();
          
            // Domain command response => Venue Dto
            this.CreateMap<object, VenueDto>()
               .ForMember(dto => dto.Id, m => m.MapFrom(e => (e as Venue).Id))
               .ForMember(dto => dto.Description, m => m.MapFrom(e => (e as Venue).Description))
               .ForMember(dto => dto.Address, m => m.MapFrom(e => (e as Venue).Address))
               .ForMember(dto => dto.Phone, m => m.MapFrom(e => (e as Venue).Phone))
               .PreserveReferences();
        }
    }
}