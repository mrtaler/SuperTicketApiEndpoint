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
    public class CommandProfile
        : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandProfile"/> class. 
        /// </summary>
        public CommandProfile()
        {
            // Create command
            this.CreateMap<CreateAreaDomainCommand, PresenterCreateAreaCommand>()
                .PreserveReferences();
            this.CreateMap<CreateEventAreaDomainCommand, PresenterCreateEventAreaCommand>()
               .PreserveReferences();
            this.CreateMap<CreateEventDomainCommand, PresenterCreateEventCommand>()
               .PreserveReferences();
            this.CreateMap<CreateEventSeatDomainCommand, PresenterCreateEventSeatCommand>()
               .PreserveReferences();
            this.CreateMap<CreateLayoutDomainCommand, PresenterCreateLayoutCommand>()
               .PreserveReferences();
            this.CreateMap<CreateSeatDomainCommand, PresenterCreateSeatCommand>()
               .PreserveReferences();
            this.CreateMap<CreateVenueDomainCommand, PresenterCreateVenueCommand>()
               .PreserveReferences();

            // Create command
            this.CreateMap<UpdateAreaDomainCommand, PresenterUpdateAreaCommand>()
                .PreserveReferences();
            this.CreateMap<UpdateEventAreaDomainCommand, PresenterUpdateEventAreaCommand>()
               .PreserveReferences();
            this.CreateMap<UpdateEventDomainCommand, PresenterUpdateEventCommand>()
               .PreserveReferences();
            this.CreateMap<UpdateEventSeatDomainCommand, PresenterUpdateEventSeatCommand>()
               .PreserveReferences();
            this.CreateMap<UpdateLayoutDomainCommand, PresenterUpdateLayoutCommand>()
               .PreserveReferences();
            this.CreateMap<UpdateSeatDomainCommand, PresenterUpdateSeatCommand>()
               .PreserveReferences();
            this.CreateMap<UpdateVenueDomainCommand, PresenterUpdateVenueCommand>()
               .PreserveReferences();

            // Create command
            this.CreateMap<DeleteAreaDomainCommand, PresenterDeleteAreaCommand>()
                .PreserveReferences();
            this.CreateMap<DeleteEventAreaDomainCommand, PresenterDeleteEventAreaCommand>()
               .PreserveReferences();
            this.CreateMap<DeleteEventDomainCommand, PresenterDeleteEventCommand>()
               .PreserveReferences();
            this.CreateMap<DeleteEventSeatDomainCommand, PresenterDeleteEventSeatCommand>()
               .PreserveReferences();
            this.CreateMap<DeleteLayoutDomainCommand, PresenterDeleteLayoutCommand>()
               .PreserveReferences();
            this.CreateMap<DeleteSeatDomainCommand, PresenterDeleteSeatCommand>()
               .PreserveReferences();
            this.CreateMap<DeleteVenueDomainCommand, PresenterDeleteVenueCommand>()
               .PreserveReferences();
        }
    }
}