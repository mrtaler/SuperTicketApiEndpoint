namespace SuperTicketApi.Domain.MainContext.Mssql
{
    using System.Reflection;

    using Autofac;

    using MediatR.Extensions.Autofac.DependencyInjection;

    using SuperTicketApi.Domain.MainContext.DTO;
    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.MainContext.Mssql.CQRS.QueryHandlers;
    using SuperTicketApi.Domain.MainContext.Mssql.Database;
    using SuperTicketApi.Domain.MainContext.Mssql.UnitOfWorks;
    using SuperTicketApi.Domain.MainContext.Queries.GetListOfDomainEntity;
    using SuperTicketApi.Domain.Seedwork;

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
            builder.RegisterType<UnitOfWork>()
                .As<ITabledUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterType<SqlServerSqlHelper>()
                .As<ISqlHelper>().InstancePerLifetimeScope();

            builder.AddMediatR(
                typeof(EnumerableAreaDomainQueryHandler).GetTypeInfo().Assembly,
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
    }
}

