namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS
{
    using System.Data;
    using System.Linq;
    using System.Reflection;

    using MediatR;

    using Serilog;

    using SuperTicketApi.Domain.MainContext.DTO.Attributes;
    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;
    using SuperTicketApi.Domain.Seedwork;

    /// <summary>
    /// base query command Handler
    /// </summary>
    public class BaseHandler
    {
        protected readonly INetUnitOfWork uow;
        protected readonly IDbCommand command;
        protected readonly IMediator mediatr;

        public BaseHandler(IUnitOfWorkFactory factory, IMediator mediatr)
        {
            this.uow = factory.Create();
            this.command = uow.CreateCommand();
            this.mediatr = mediatr;
            Log.Information($"{this.GetType().Name} was started");
        }

        protected string GetIdTableColumnName<T>() where T : DomainEntity
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(p => p.GetCustomAttributes(typeof(IdColumnAttribute), false).Count() == 1);

            var dataBaseAttribute = (properties.GetCustomAttributes(typeof(DbColumnAttribute), true).FirstOrDefault() as DbColumnAttribute).columnName;

            /*var dnAttribute = item.GetCustomAttributes(
                        typeof(IdColumnAttribute), true
                    ).FirstOrDefault() as IdColumnAttribute;*/

            return dataBaseAttribute;
        }
    }
}
