namespace SuperTicketApi.Application.MainContext
{
    using Autofac;

    using SuperTicketApi.Application.MainContext.Implimentation;
    using SuperTicketApi.Application.MainContext.Interfaces;

    public class MainContextModule : Module
    {
        /// <inheritdoc />
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<EventAddressService>().As<IEventAddressService>();
            builder.RegisterType<EventPlaceService>().As<IEventPlaceService>();
            builder.RegisterType<EventService>().As<IEventService>();
        }
    }
}
