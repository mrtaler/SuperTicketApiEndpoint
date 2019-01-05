namespace SuperTicketApi.Domain.MainContext.Mssql
{
    using Autofac;
    using MediatR.Extensions.Autofac.DependencyInjection;
    using SuperTicketApi.ApiSettings.JsonSettings.ConnectionStrings;
    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.MainContext.Mssql.CQRS.QueryHandlers;
    using SuperTicketApi.Domain.MainContext.Mssql.UnitOfWorks;
    using SuperTicketApi.Domain.MainContext.Queries.GetListOfDomainEntity;
    using SuperTicketApi.Domain.Seedwork;
    using System.Reflection;
    using IUnitOfWorkFactory = SuperTicketApi.Domain.MainContext.Mssql.Interfaces.IUnitOfWorkFactory;

    /// <summary>
    /// The new module.
    /// </summary>
    public class MainContextMssqlModule :Autofac.Module
    {
       /* public MainContextMssqlModule()
        {
            connectionString = connection;
        }
        /*/
        /// <inheritdoc />
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .Register(c => new UnitOfWorkFactory(
                    c.Resolve<AppConnectionStrings>().MssqlConnectionString))
                // IOptions <AppConnectionStrings>>().Value.MssqlConnectionString
                .As<IUnitOfWorkFactory>().InstancePerLifetimeScope();

            builder
                .RegisterType<UnitOfWork>()
                .As<IUnitOfWork>().InstancePerLifetimeScope();

                builder
                    .RegisterType<AdoNetUnitOfWork>()
                    .As<INetUnitOfWork>().InstancePerLifetimeScope();


            builder.AddMediatR(typeof(GetQueryAsIEnumerableQueryHandler).GetTypeInfo().Assembly, typeof(GetAreaAsIEnumerableQuery).GetTypeInfo().Assembly, typeof(Area).GetTypeInfo().Assembly);
        }
    }
}

