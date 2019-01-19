namespace SuperTicketApi.Application.MainContext
{
    using Autofac;
    using FluentValidation;
    using MediatR.Extensions.Autofac.DependencyInjection;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Create;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Delete;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Update;
    using SuperTicketApi.Application.MainContext.Cqrs.Validators;
    using System.Reflection;

    using MediatR;

    using SuperTicketApi.Application.MainContext.Cqrs;

    /// <summary>
    /// The main context module.
    /// </summary>
    public class MainContextModule : Autofac.Module
    {
        /// <inheritdoc />
        protected override void Load(ContainerBuilder builder)
        {
            ContainerBuilderExtensions.AddMediatR(builder, typeof(PresenterCreateAreaCommand).GetTypeInfo().Assembly);
            ContainerBuilderExtensions.AddMediatR(builder, typeof(PresenterUpdateAreaCommand).GetTypeInfo().Assembly);
            ContainerBuilderExtensions.AddMediatR(builder, typeof(PresenterDeleteAreaCommand).GetTypeInfo().Assembly);

            builder.RegisterType<AreasCreateValidator>()
                .As(typeof(AbstractValidator<PresenterCreateAreaCommand>));
            builder.RegisterType<EventAreaCreateValidator>()
                .As(typeof(AbstractValidator<PresenterCreateEventAreaCommand>));
            builder.RegisterType<EventCreateValidator>()
                .As(typeof(AbstractValidator<PresenterCreateEventCommand>));
            builder.RegisterType<EventSeatCreateValidator>()
                .As(typeof(AbstractValidator<PresenterCreateEventSeatCommand>));
            builder.RegisterType<LayoutCreateValidator>()
                .As(typeof(AbstractValidator<PresenterCreateLayoutCommand>));
            builder.RegisterType<SeatCreateValidator>()
                .As(typeof(AbstractValidator<PresenterCreateSeatCommand>));
            builder.RegisterType<VenueCreateValidator>()
                .As(typeof(AbstractValidator<PresenterCreateVenueCommand>));

              builder.RegisterGeneric(typeof(ValidationBehavior<,>)).As(typeof(IPipelineBehavior<,>));

            // builder.RegisterType<EventAddressService>().As<IEventAddressService>();
            // builder.RegisterType<EventPlaceService>().As<IEventPlaceService>();
            // builder.RegisterType<EventService>().As<IEventService>();
        }
    }
}
