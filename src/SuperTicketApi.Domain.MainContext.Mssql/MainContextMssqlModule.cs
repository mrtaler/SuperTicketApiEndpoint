namespace SuperTicketApi.Domain.MainContext.Mssql
{
    using Autofac;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Options;

    using SuperTicketApi.ApiSettings.JsonSettings.ConnectionStrings;
    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;

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
                    c.Resolve<AppConnectionStrings>().MssqlConnectionString
                   // c.Resolve<IConfiguration>().GetSection("AppConnectionStrings:MssqlConnectionString").Value



                      /*  IOptions <AppConnectionStrings>>().Value.MssqlConnectionString*/))
                .As<IUnitOfWorkFactory>().InstancePerLifetimeScope();

            builder
                .RegisterType<UnitOfWork>()
                .As<IUnitOfWorkMssql>().InstancePerLifetimeScope();

        }
    }
}

