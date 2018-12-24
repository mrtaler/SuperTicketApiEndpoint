namespace SuperTicketApi.Application.Seedwork.Common
{
    using System.Collections.Generic;

    using SuperTicketApi.Domain.Seedwork;

    public interface IReadableService<TEntity, TEntityDto>
        where TEntity : Entity
        where TEntityDto : Entity
    {
        TEntity Get(object id);
        TEntityDto GetDto(object id);

        IEnumerable<TEntity> GetAll();
        IList<TEntityDto> GetAllDto();
    }
}