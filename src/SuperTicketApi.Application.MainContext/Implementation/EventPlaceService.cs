﻿namespace SuperTicketApi.Application.MainContext.Implementation
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

    /// <inheritdoc cref="IEventPlaceService"/>
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
            using (var context = this.uow.Create())
            {
                return context.EventPlaces.GetAll(
                    new DbColumns<EventPlace>(new List<Expression<Func<EventPlace, string>>> {
                        x =>nameof(x.CostPerHour),
                        x =>nameof(x.Id),
                        x =>nameof(x.PlacesAdmin)
                    }));
            }
        }

        /// <inheritdoc />
        public override IList<EventPlaceDto> GetAllDto()
        {
            using (var context = this.uow.Create())
            {
                var entities = context.EventPlaces.GetAll(
                    new DbColumns<EventPlace>(new List<Expression<Func<EventPlace, string>>> {
                        x =>nameof(x.CostPerHour),
                        x =>nameof(x.Id),
                        x =>nameof(x.PlacesAdmin)
                    }));
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