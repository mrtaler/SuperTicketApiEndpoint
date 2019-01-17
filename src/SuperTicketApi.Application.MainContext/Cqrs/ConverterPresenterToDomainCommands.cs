namespace SuperTicketApi.Application.MainContext.Cqrs
{
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Create;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Delete;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Update;
    using SuperTicketApi.Domain.MainContext.Command.CreateCommands;
    using SuperTicketApi.Domain.MainContext.Command.Delete;
    using SuperTicketApi.Domain.MainContext.Command.Update;

    /// <summary>
    /// The area dto profile.
    /// </summary>
    public class ConverterPresenterToDomainCommands
        : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConverterPresenterToDomainCommands"/> class. 
        /// </summary>
        public ConverterPresenterToDomainCommands()
        {
            // Create command
            this.CreateMap<PresenterCreateAreaCommand, CreateAreaDomainCommand>()
                .PreserveReferences();
            this.CreateMap<PresenterCreateEventAreaCommand, CreateEventAreaDomainCommand>()
               .PreserveReferences();
            this.CreateMap<PresenterCreateEventCommand, CreateEventDomainCommand>()
               .PreserveReferences();
            this.CreateMap<PresenterCreateEventSeatCommand, CreateEventSeatDomainCommand>()
               .PreserveReferences();
            this.CreateMap<PresenterCreateLayoutCommand, CreateLayoutDomainCommand>()
               .PreserveReferences();
            this.CreateMap<PresenterCreateSeatCommand, CreateSeatDomainCommand>()
               .PreserveReferences();
            this.CreateMap<PresenterCreateVenueCommand, CreateVenueDomainCommand>()
               .PreserveReferences();

            // Create command
            this.CreateMap<PresenterUpdateAreaCommand, UpdateAreaDomainCommand>()
                .PreserveReferences();
            this.CreateMap<PresenterUpdateEventAreaCommand, UpdateEventAreaDomainCommand>()
               .PreserveReferences();
            this.CreateMap<PresenterUpdateEventCommand, UpdateEventDomainCommand>()
               .PreserveReferences();
            this.CreateMap<PresenterUpdateEventSeatCommand, UpdateEventSeatDomainCommand>()
               .PreserveReferences();
            this.CreateMap<PresenterUpdateLayoutCommand, UpdateLayoutDomainCommand>()
               .PreserveReferences();
            this.CreateMap<PresenterUpdateSeatCommand, UpdateSeatDomainCommand>()
               .PreserveReferences();
            this.CreateMap<PresenterUpdateVenueCommand, UpdateVenueDomainCommand>()
               .PreserveReferences();

            // Create command
            this.CreateMap<PresenterDeleteAreaCommand, DeleteAreaDomainCommand>()
                .PreserveReferences();
            this.CreateMap<PresenterDeleteEventAreaCommand, DeleteEventAreaDomainCommand>()
               .PreserveReferences();
            this.CreateMap<PresenterDeleteEventCommand, DeleteEventDomainCommand>()
               .PreserveReferences();
            this.CreateMap<PresenterDeleteEventSeatCommand, DeleteEventSeatDomainCommand>()
               .PreserveReferences();
            this.CreateMap<PresenterDeleteLayoutCommand, DeleteLayoutDomainCommand>()
               .PreserveReferences();
            this.CreateMap<PresenterDeleteSeatCommand, DeleteSeatDomainCommand>()
               .PreserveReferences();
            this.CreateMap<PresenterDeleteVenueCommand, DeleteVenueDomainCommand>()
               .PreserveReferences();
        }
    }
}