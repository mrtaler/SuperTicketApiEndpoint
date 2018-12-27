namespace SuperTicketApi.Application.MainContext.Implementation
{
    using System.Collections.Generic;

    using SuperTicketApi.Application.BoundedContext.DTO.Dto;
    using SuperTicketApi.Application.MainContext.Interfaces;
    using SuperTicketApi.Application.Seedwork;
    using SuperTicketApi.Application.Seedwork.Common;
    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;
    using SuperTicketApi.Domain.MainContext.Mssql.Models;

    /// <inheritdoc cref="IEventService"/>
    public class EventService : Service<Events, EventDto>, IEventService
    {
        /// <inheritdoc />
        public EventService(IUnitOfWorkFactory _uow)
            : base(_uow)
        {
        }

        #region Overrides of Service<EventAddress,EventAddressDto>

        /// <inheritdoc />
        public override IEnumerable<Events> GetAll()
        {
            using (var context = this.uow.Create())
            {
                return context.Events.GetAll();
            }
        }

        /// <inheritdoc />
        public override IList<EventDto> GetAllDto()
        {
            using (var context = this.uow.Create())
            {
                var entities = context.Events.GetAll();
                if (entities != null)
                {
                    return entities.ProjectedAsCollection<EventDto>();
                }

                return null;
            }
        }

        #endregion
    }
}