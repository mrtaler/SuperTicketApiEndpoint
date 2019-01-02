namespace SuperTicketApi.Application.MainContext.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using SuperTicketApi.Application.BoundedContext.DTO.Dto;
    using SuperTicketApi.Application.MainContext.Interfaces;
    using SuperTicketApi.Application.Seedwork;
    using SuperTicketApi.Application.Seedwork.Common;
    using SuperTicketApi.Domain.MainContext.Mssql.Implimentation;
    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;
    using SuperTicketApi.Domain.MainContext.Mssql.Models;

    /// <inheritdoc cref="IEventAddressService"/>
    public class EventAddressService : Service<EventAddress, EventAddressDto>, IEventAddressService
    {
        /// <inheritdoc />
        public EventAddressService(IUnitOfWorkFactory _uow)
            : base(_uow)
        {
        }

        #region Overrides of Service<EventAddress,EventAddressDto>

        /// <inheritdoc />
        public override IEnumerable<EventAddress> GetAll()
        {
            using (var context = this.uow.Create())
            {
                return context.EventAddreses.GetAll(
                    new DbColumns<EventAddress>(new List<Expression<Func<EventAddress, string>>> {
                        x =>nameof(x.Street),
                        x =>nameof(x.Id),
                        x =>nameof(x.House)
                    }));
            }
        }

        /// <inheritdoc />
        public override IList<EventAddressDto> GetAllDto()
        {
            using (var context = this.uow.Create())
            {
                var entities = context.EventAddreses.GetAll(
                    new DbColumns<EventAddress>(new List<Expression<Func<EventAddress, string>>> {
                                  x =>nameof(x.Street),
                        x =>nameof(x.Id),
                        x =>nameof(x.House)
                    }));
                if (entities != null)
                {
                    return entities.ProjectedAsCollection<EventAddressDto>();
                }

                return null;
            }
        }

        #endregion
    }
}
