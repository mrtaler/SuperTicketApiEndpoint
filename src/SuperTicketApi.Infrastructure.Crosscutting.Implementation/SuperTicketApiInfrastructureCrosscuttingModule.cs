namespace SuperTicketApi.Infrastructure.Crosscutting.Implementation
{
    using Autofac;
    using MediatR;
    using SuperTicketApi.Infrastructure.Crosscutting.Adapter;
    using SuperTicketApi.Infrastructure.Crosscutting.Implementation.Adapter;
    using SuperTicketApi.Infrastructure.Crosscutting.Implementation.Pipeline;

    /// <summary>
    /// The new module.
    /// </summary>
    public class SuperTicketApiInfrastructureCrosscuttingModule : Module
    {
        /// <inheritdoc />
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AutomapperTypeAdapterFactory>().As<ITypeAdapterFactory>();


            /*            builder.RegisterGeneric(typeof(NotificationsAndTracingBehavior<,>))
                           .As(typeof(IPipelineBehavior<,>))
                           .InstancePerLifetimeScope();
*/
                    builder.RegisterGeneric(typeof(PerformanceBehavior<,>))
                           .As(typeof(IPipelineBehavior<,>))
                           .InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(ExceptionHandler<,>))
                          .As(typeof(IPipelineBehavior<,>))
                          .InstancePerLifetimeScope();

            /*           builder.RegisterGeneric(typeof(RequestPreProcessorBehavior<,>))
                           .As(typeof(IPipelineBehavior<,>))
                           .InstancePerLifetimeScope();*/
        }
    }
}
