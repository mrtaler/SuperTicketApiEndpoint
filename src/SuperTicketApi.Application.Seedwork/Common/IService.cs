namespace SuperTicketApi.Application.Seedwork.Common
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SuperTicketApi.Domain.Seedwork;

    public interface IService<TEntity, TEntityDto> : IDisposable
       where TEntity : Entity
       where TEntityDto : Entity
    {
        TEntity Add(TEntity item);
        TEntityDto Add(TEntityDto item);

        IEnumerable<TEntity> Add(IEnumerable<TEntity> items);
        IList<TEntityDto> Add(IList<TEntityDto> items);

        Task<TEntity> AddAsync(TEntity item);
        Task<TEntityDto> AddAsync(TEntityDto item);

        Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> items);
        Task<IList<TEntityDto>> AddAsync(IList<TEntityDto> item);

        void Remove(TEntity item);
        void Remove(TEntityDto item);
        void Remove(object id);

        void Remove(IEnumerable<TEntity> items);
        void Remove(IList<TEntityDto> items);
        void Remove(IEnumerable<object> ids);

        Task RemoveAsync(TEntity item);
        Task RemoveAsync(TEntityDto item);
        Task RemoveAsync(object id);

        Task RemoveAsync(IEnumerable<TEntity> items);
        Task RemoveAsync(IList<TEntityDto> items);
        Task RemoveAsync(IEnumerable<object> ids);

        TEntity Modify(TEntity item);
        TEntityDto Modify(TEntityDto item);

        IEnumerable<TEntity> Modify(IEnumerable<TEntity> items);
        IList<TEntityDto> Modify(IList<TEntityDto> items);

        TEntity Modify(object id, TEntity item);
        TEntityDto Modify(object id, TEntityDto item);

        Task<TEntity> ModifyAsync(TEntity item);
        Task<TEntityDto> ModifyAsync(TEntityDto item);

        Task<IEnumerable<TEntity>> ModifyAsync(IEnumerable<TEntity> items);
        Task<IList<TEntityDto>> ModifyAsync(IList<TEntityDto> items);

        Task<TEntity> ModifyAsync(object id, TEntity item);
        Task<TEntityDto> ModifyAsync(object id, TEntityDto item);

        void Refresh(TEntity item);
        void Refresh(TEntityDto item);

        TEntity Get(object id);
        TEntityDto GetDto(object id);

        Task<TEntity> GetAsync(object id);
        Task<TEntityDto> GetDtoAsync(object id);

        IEnumerable<TEntity> GetAll();
        IList<TEntityDto> GetAllDto();

        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IList<TEntityDto>> GetAllDtoAsync();
    }
}
