namespace SuperTicketApi.Domain.MainContext.Mssql
{
    using System.Reflection;

    using Autofac;

    using MediatR.Extensions.Autofac.DependencyInjection;

    using Microsoft.Extensions.Options;

    using SuperTicketApi.ApiSettings.JsonSettings.ConnectionStrings;
    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.MainContext.Mssql.CQRS.QueryHandlers;
    using SuperTicketApi.Domain.MainContext.Mssql.UnitOfWorks;
    using SuperTicketApi.Domain.MainContext.Queries.GetListOfDomainEntity;
    using SuperTicketApi.Domain.Seedwork;

    using IUnitOfWorkFactory = SuperTicketApi.Domain.MainContext.Mssql.Interfaces.IUnitOfWorkFactory;

    /// <summary>
    /// The new module.
    /// </summary>
    public class MainContextMssqlModule : Autofac.Module
    {
        /* public MainContextMssqlModule()
         {
             connectionString = connection;
         }
         /*/

        /// <inheritdoc />
        protected override void Load(ContainerBuilder builder)
        {

            builder.Register(c => new UnitOfWorkFactory(
                    c.Resolve<IOptions <AppConnectionStrings>>().Value.MssqlConnectionString))

                // IOptions <AppConnectionStrings>>().Value.MssqlConnectionString
                .As<IUnitOfWorkFactory>().InstancePerLifetimeScope();

            /* builder
                 .RegisterType<UnitOfWork>()
                 .As<IUnitOfWork>().InstancePerLifetimeScope();*/
            builder.RegisterType<AdoNetUnitOfWork>().As<INetUnitOfWork>().InstancePerLifetimeScope();

            builder.AddMediatR(
                typeof(GetQueryAsIEnumerableQueryHandler).GetTypeInfo().Assembly,
                typeof(GetAreaAsIEnumerableQuery).GetTypeInfo().Assembly,
                typeof(Area).GetTypeInfo().Assembly);

            /*            builder.RegisterGeneric(typeof(NotificationsAndTracingBehavior<,>))
                            .As(typeof(IPipelineBehavior<,>))
                            .InstancePerLifetimeScope();

                        builder.RegisterGeneric(typeof(PerformanceBehavior<,>))
                            .As(typeof(IPipelineBehavior<,>))
                            .InstancePerLifetimeScope();

                        builder.RegisterGeneric(typeof(RequestPreProcessorBehavior<,>))
                            .As(typeof(IPipelineBehavior<,>))
                            .InstancePerLifetimeScope();*/

            /*   builder.RegisterType(typeof(RequestPreProcessorBehavior<,>))
              .As(typeof(IPipelineBehavior<,>));*/

            /*
             builder.RegisterGeneric(typeof(IPipelineBehavior<,>)).As(typeof(GenericPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(IRequestPreProcessor<>)).As(typeof(GenericRequestPreProcessor<>));
            builder.RegisterGeneric(typeof(IRequestPostProcessor<,>)).As(typeof(GenericRequestPostProcessor<,>));
            */
        }

        // https://github.com/INNVTV/NetCore-Clean-Architecture
    }
}

