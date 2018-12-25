namespace SuperTicketApi.Domain.MainContext.Mssql
{
    using Autofac;
    using Microsoft.Extensions.Options;

    using SuperTicketApi.ApiSettings.JsonSettings.ConnectionStrings;
    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;
    using SuperTicketApi.Domain.Seedwork;

    using IUnitOfWorkFactory = SuperTicketApi.Domain.MainContext.Mssql.Interfaces.IUnitOfWorkFactory;

    /// <summary>
    /// The new module.
    /// </summary>
    public class MainContextMssqlModule : Module
    {
        /// <inheritdoc />
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .Register(c => new UnitOfWorkFactory(
                    c.Resolve<IOptions<AppConnectionStrings>>().Value.MssqlConnectionString))
                .As<IUnitOfWorkFactory>().InstancePerLifetimeScope();

            builder
                .RegisterType<UnitOfWork>()
                .As<IUnitOfWorkMssql>().InstancePerLifetimeScope();

        }
    }
}

