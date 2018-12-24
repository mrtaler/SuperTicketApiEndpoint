using System;
using System.Collections.Generic;

namespace SuperTicketApi.Application.MainContext.Implimentation
{
    using SuperTicketApi.Application.BoundedContext.DTO.Dto;
    using SuperTicketApi.Application.MainContext.Interfaces;
    using SuperTicketApi.Application.Seedwork;
    using SuperTicketApi.Application.Seedwork.Common;
    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;
    using SuperTicketApi.Domain.MainContext.Mssql.Models;
    using SuperTicketApi.Domain.Seedwork.Repository;

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
                return context.EventAddreses.GetAll();
            }
        }

        /// <inheritdoc />
        public override IList<EventAddressDto> GetAllDto()
        {
            using (var context = this.uow.Create())
            {
                var entities = context.EventAddreses.GetAll();
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
