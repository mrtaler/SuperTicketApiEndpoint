namespace SuperTicketApi.Application.MainContext.Cqrs
{
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Create;
    using SuperTicketApi.Domain.MainContext.Command.CreateCommands;

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
        }
    }
}