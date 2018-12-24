﻿namespace SuperTicketApi.Application.MainContext.Interfaces
{
    using SuperTicketApi.Application.BoundedContext.DTO.Dto;
    using SuperTicketApi.Application.Seedwork.Common;
    using SuperTicketApi.Domain.MainContext.Mssql.Models;

    public interface IEventPlaceService: IService<EventPlace, EventPlaceDto>
    {

    }
}