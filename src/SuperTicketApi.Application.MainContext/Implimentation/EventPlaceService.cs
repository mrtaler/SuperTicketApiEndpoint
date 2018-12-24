namespace SuperTicketApi.Application.MainContext.Implimentation
{
    using System.Collections.Generic;

    using SuperTicketApi.Application.BoundedContext.DTO.Dto;
    using SuperTicketApi.Application.MainContext.Interfaces;
    using SuperTicketApi.Application.Seedwork;
    using SuperTicketApi.Application.Seedwork.Common;
    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;
    using SuperTicketApi.Domain.MainContext.Mssql.Models;
    using SuperTicketApi.Domain.Seedwork.Repository;

    public class EventPlaceService : Service<EventPlace, EventPlaceDto>, IEventPlaceService
    {
        /// <inheritdoc />
        public EventPlaceService(IUnitOfWorkFactory _uow)
            : base(_uow)
        {
        }

        #region Overrides of Service<EventAddress,EventAddressDto>

        /// <inheritdoc />
        public override IEnumerable<EventPlace> GetAll()
        {
            using (var context = uow.Create())
            {
                return context.EventPlaces.GetAll();
            }
        }

        /// <inheritdoc />
        public override IList<EventPlaceDto> GetAllDto()
        {
            using (var context = uow.Create())
            {
                var entities = context.EventPlaces.GetAll();
                if (entities != null)
                {
                    return entities.ProjectedAsCollection<EventPlaceDto>();
                }
                return null;
            }
        }

        #endregion
    }
}