namespace SuperTicketApi.Infrastructure.Crosscutting.Implementation
{
    using Autofac;

    using SuperTicketApi.Infrastructure.Crosscutting.Adapter;
    using SuperTicketApi.Infrastructure.Crosscutting.Implementation.Adapter;

    /// <summary>
    /// The new module.
    /// </summary>
    public class SuperTicketApiInfrastructureCrosscuttingModule : Module
    {
        /// <inheritdoc />
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AutomapperTypeAdapterFactory>().As<ITypeAdapterFactory>();
        }
    }
}
