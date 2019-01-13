﻿namespace SuperTicketApi.ApiEndpoint.ViewModel
{
    using SuperTicketApi.ApiEndpoint.ViewModel.Area;
    using SuperTicketApi.ApiEndpoint.ViewModel.Event;
    using SuperTicketApi.ApiEndpoint.ViewModel.EventArea;
    using SuperTicketApi.ApiEndpoint.ViewModel.EventSeat;
    using SuperTicketApi.ApiEndpoint.ViewModel.Layout;
    using SuperTicketApi.ApiEndpoint.ViewModel.Seat;
    using SuperTicketApi.ApiEndpoint.ViewModel.Venue;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Create;

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
            #region Create presenter Command

            this.CreateMap<CreateAreaViewModel, PresenterCreateAreaCommand>()
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<CreateEventAreaViewModel, PresenterCreateEventAreaCommand>()
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<CreateEventViewModel, PresenterCreateEventCommand>()
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<CreateEventSeatViewModel, PresenterCreateEventSeatCommand>()
                .ForMember(com => com.EventAreaId, map => map.MapFrom(e => e.EventAreasId))
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<CreateLayoutViewModel, PresenterCreateLayoutCommand>()
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<CreateSeatViewModel, PresenterCreateSeatCommand>()
                .PreserveReferences()
                .ReverseMap();

            this.CreateMap<CreateVenueViewModel, PresenterCreateVenueCommand>()
                .PreserveReferences()
                .ReverseMap();

            #endregion
        }
    }
}