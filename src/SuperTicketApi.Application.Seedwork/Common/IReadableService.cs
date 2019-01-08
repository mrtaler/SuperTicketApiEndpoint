namespace SuperTicketApi.Application.Seedwork.Common
{
    using System.Collections.Generic;
    using SuperTicketApi.Application.BoundedContext.DTO.Dto;
    using SuperTicketApi.Domain.Seedwork;

    public interface IReadableService<TEntity, TEntityDto>
        where TEntity : DomainEntity
        where TEntityDto : BusinesEntity
    {
        TEntity Get(object id);
        TEntityDto GetDto(object id);

        IEnumerable<TEntity> GetAll();
        IList<TEntityDto> GetAllDto();
    }
}