namespace SuperTicketApi.Domain.MainContext.Mssql.Implimentation
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using SuperTicketApi.Domain.MainContext.Mssql.Attributes;
    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;
    using SuperTicketApi.Domain.MainContext.Mssql.Models;
    using SuperTicketApi.Domain.Seedwork;
    using SuperTicketApi.Domain.Seedwork.Specifications.Interfaces;

    /// <inheritdoc cref="IEventRepository"/>
    public class EventRepository : GenericRepository<Events>, IEventRepository
    {
        public EventRepository(INetUnitOfWork _context)
            : base(_context)
        {
        }

        /// <inheritdoc />
        public override void Add(Events item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override void Update(Events item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override void Delete(Events item)
        {
            throw new NotImplementedException();
        }

        public override Events Mapping(IDataReader reader, IColumnSpecification<Events> columns)
        {
            var ret = new Events();
            foreach (var item in columns.Columns)
            {
                var prop = GetPropertyName(item);
                var value = typeof(Events).GetProperty(prop);

                var dnAttribute = value.GetCustomAttributes(
                            typeof(DbColumn), true
                        ).FirstOrDefault() as DbColumn;
                var colu = dnAttribute.columnName;
                
                var propToSet= ret.GetType().GetProperty(prop);
                var valueToSet = Convert.ChangeType(this.GetItem(colu, reader), propToSet.PropertyType);
                propToSet.SetValue(ret, valueToSet);
            }
           
          /*  ret.Id = (int)this.GetItem("EventId", reader);
            ret.Name = (string)this.GetItem("Name", reader);
            ret.Banner = (string)this.GetItem("Banner", reader);
            ret.Description = (string)this.GetItem("Description", reader);
            ret.StartAt = (DateTimeOffset)this.GetItem("StartAt", reader);
            ret.Runtime = (TimeSpan)this.GetItem("Runtime", reader);
            ret.Fk_EventPlaceId = (int)this.GetItem("Fk_EventPlaceId", reader);
            ret.MaxSeats = (int)this.GetItem("MaxSeats", reader);*/
            return ret;
        }

        public override Events GetById(int id, IColumnSpecification<Events> columns)
        {
            throw new NotImplementedException();
        }
    }
}
