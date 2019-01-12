namespace SuperTicketApi.Application.MainContext
{
    using System.Reflection;

    using Autofac;

    using MediatR.Extensions.Autofac.DependencyInjection;

    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Area;

    // using SuperTicketApi.Application.MainContext.Implementation;
    // using SuperTicketApi.Application.MainContext.Interfaces;
    public class MainContextModule : Autofac.Module
    {
        /// <inheritdoc />
        protected override void Load(ContainerBuilder builder)
        {
            builder.AddMediatR(typeof(AreaCommandHandler).GetTypeInfo().Assembly);

            // builder.RegisterType<EventAddressService>().As<IEventAddressService>();
            // builder.RegisterType<EventPlaceService>().As<IEventPlaceService>();
            // builder.RegisterType<EventService>().As<IEventService>();
        }
    }
}
