namespace SuperTicketApi.Application.Seedwork.Common
{
    using System.Collections.Generic;
    using SuperTicketApi.Application.BoundedContext.DTO.Dto;
    using SuperTicketApi.Domain.Seedwork;

    public interface IEditableService<TEntity, TEntityDto>
        where TEntity : DomainEntity 
        where TEntityDto : BusinesEntity
    {
        TEntity Add(TEntity item);
        TEntityDto Add(TEntityDto item);

        IEnumerable<TEntity> Add(IEnumerable<TEntity> items);
        IList<TEntityDto> Add(IList<TEntityDto> items);


        void Remove(TEntity item);
        void Remove(TEntityDto item);

        void Remove(IEnumerable<TEntity> items);
        void Remove(IList<TEntityDto> items);

        TEntity Modify(TEntity item);
        TEntityDto Modify(TEntityDto item);

        IEnumerable<TEntity> Modify(IEnumerable<TEntity> items);
        IList<TEntityDto> Modify(IList<TEntityDto> items);



        void Refresh(TEntity item);
        void Refresh(TEntityDto item);
    }
}