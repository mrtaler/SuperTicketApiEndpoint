namespace SuperTicketApi.Application.Seedwork.Common
{
    using System.Collections.Generic;

    using SuperTicketApi.Application.BoundedContext.DTO;
    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.Seedwork;

    using IBusinessDto = SuperTicketApi.Application.Seedwork.IBusinessDto;

    public interface IReadableService<TEntity, TEntityDto>
        where TEntity : DomainEntity
        where TEntityDto : IBusinessDto
    {
        TEntity Get(object id);
        TEntityDto GetDto(object id);

        IEnumerable<TEntity> GetAll();
        IList<TEntityDto> GetAllDto();
    }
}