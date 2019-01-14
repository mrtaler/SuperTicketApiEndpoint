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
            this.CreateMap<PresenterCreateAreaCommand ,CreateAreaDomainCommand>()
                .PreserveReferences();
            this.CreateMap<PresenterCreateEventAreaCommand,CreateEventAreaDomainCommand >()
               .PreserveReferences();
            this.CreateMap<PresenterCreateEventCommand,CreateEventDomainCommand >()
               .PreserveReferences();
            this.CreateMap<PresenterCreateEventSeatCommand,CreateEventSeatDomainCommand >()
               .PreserveReferences();
            this.CreateMap<PresenterCreateLayoutCommand,CreateLayoutDomainCommand >()
               .PreserveReferences();
            this.CreateMap<PresenterCreateSeatCommand,CreateSeatDomainCommand >()
               .PreserveReferences();
            this.CreateMap<PresenterCreateVenueCommand,CreateVenueDomainCommand >()
               .PreserveReferences();

            // Create command
            this.CreateMap<PresenterUpdateAreaCommand , UpdateAreaDomainCommand>()
                .PreserveReferences();
            this.CreateMap<PresenterUpdateEventAreaCommand,UpdateEventAreaDomainCommand >()
               .PreserveReferences();
            this.CreateMap<PresenterUpdateEventCommand,UpdateEventDomainCommand >()
               .PreserveReferences();
            this.CreateMap<PresenterUpdateEventSeatCommand,UpdateEventSeatDomainCommand >()
               .PreserveReferences();
            this.CreateMap<PresenterUpdateLayoutCommand,UpdateLayoutDomainCommand >()
               .PreserveReferences();
            this.CreateMap<PresenterUpdateSeatCommand,UpdateSeatDomainCommand >()
               .PreserveReferences();
            this.CreateMap<PresenterUpdateVenueCommand,UpdateVenueDomainCommand >()
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