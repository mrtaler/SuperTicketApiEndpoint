namespace SuperTicketApi.Application.MainContext
{
    using System.Reflection;

    using Autofac;

    using MediatR.Extensions.Autofac.DependencyInjection;

    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Create;

    /// <summary>
    /// The main context module.
    /// </summary>
    public class MainContextModule : Autofac.Module
    {
        /// <inheritdoc />
        protected override void Load(ContainerBuilder builder)
        {
            builder.AddMediatR(typeof(PresenterCreateAreaCommand).GetTypeInfo().Assembly);

            // builder.RegisterType<EventAddressService>().As<IEventAddressService>();
            // builder.RegisterType<EventPlaceService>().As<IEventPlaceService>();
            // builder.RegisterType<EventService>().As<IEventService>();
        }
    }
}
