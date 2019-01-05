//namespace SuperTicketApi.Application.MainContext.Implementation
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq.Expressions;
//    using SuperTicketApi.Application.BoundedContext.DTO.Dto;
//    using SuperTicketApi.Application.MainContext.Interfaces;
//    using SuperTicketApi.Application.Seedwork;
//    using SuperTicketApi.Application.Seedwork.Common;
//    using SuperTicketApi.Domain.MainContext.DTO.Models;
//    using SuperTicketApi.Domain.MainContext.Mssql.Implimentation;
//    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;

//    /// <inheritdoc cref="IEventService"/>
//    public class EventService : Service<Event, EventDto>, IEventService
//    {
//        /// <inheritdoc />
//        public EventService(IUnitOfWorkFactory _uow)
//            : base(_uow)
//        {
//        }

//        #region Overrides of Service<EventAddress,EventAddressDto>

//        /// <inheritdoc />
//        public override IEnumerable<Event> GetAll()
//        {
//            using (var context = this.uow.Create())
//            {
//                return context.Event.GetAll(
//                    new DbColumns<Events>(new List<Expression<Func<Events, string>>> {
//                        x =>nameof(x.Banner),
//                        x =>nameof(x.Id),
//                        x =>nameof(x.Name)
//                    }));
//            }
//        }

//        /// <inheritdoc />
//        public override IList<EventDto> GetAllDto()
//        {
//            using (var context = this.uow.Create())
//            {
//                var entities = context.Events.GetAll(
//                    new DbColumns<Events>(new List<Expression<Func<Events, string>>> {
//                        x =>nameof(x.Banner),
//                        x =>nameof(x.Id),
//                        x =>nameof(x.Name)
//                    }));
//                if (entities != null)
//                {
//                    return entities.ProjectedAsCollection<EventDto>();
//                }

//                return null;
//            }
//        }

//        #endregion
//    }
//}