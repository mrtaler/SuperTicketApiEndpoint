namespace SuperTicketApi.Application.Seedwork.Common
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IService<TEntity, TEntityDTO> : IDisposable
       where TEntity : Entity
       where TEntityDTO : Entity
    {
        TEntity Add(TEntity item);
        TEntityDTO Add(TEntityDTO item);

        IEnumerable<TEntity> Add(IEnumerable<TEntity> items);
        IList<TEntityDTO> Add(IList<TEntityDTO> items);

        Task<TEntity> AddAsync(TEntity item);
        Task<TEntityDTO> AddAsync(TEntityDTO item);

        Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> items);
        Task<IList<TEntityDTO>> AddAsync(IList<TEntityDTO> item);

        void Remove(TEntity item);
        void Remove(TEntityDTO item);
        void Remove(object id);

        void Remove(IEnumerable<TEntity> items);
        void Remove(IList<TEntityDTO> items);
        void Remove(IEnumerable<object> ids);

        Task RemoveAsync(TEntity item);
        Task RemoveAsync(TEntityDTO item);
        Task RemoveAsync(object id);

        Task RemoveAsync(IEnumerable<TEntity> items);
        Task RemoveAsync(IList<TEntityDTO> items);
        Task RemoveAsync(IEnumerable<object> ids);

        TEntity Modify(TEntity item);
        TEntityDTO Modify(TEntityDTO item);

        IEnumerable<TEntity> Modify(IEnumerable<TEntity> items);
        IList<TEntityDTO> Modify(IList<TEntityDTO> items);

        TEntity Modify(object id, TEntity item);
        TEntityDTO Modify(object id, TEntityDTO item);

        Task<TEntity> ModifyAsync(TEntity item);
        Task<TEntityDTO> ModifyAsync(TEntityDTO item);

        Task<IEnumerable<TEntity>> ModifyAsync(IEnumerable<TEntity> items);
        Task<IList<TEntityDTO>> ModifyAsync(IList<TEntityDTO> items);

        Task<TEntity> ModifyAsync(object id, TEntity item);
        Task<TEntityDTO> ModifyAsync(object id, TEntityDTO item);

        void Refresh(TEntity item);
        void Refresh(TEntityDTO item);

        TEntity Get(object id);
        TEntityDTO GetDTO(object id);

        Task<TEntity> GetAsync(object id);
        Task<TEntityDTO> GetDTOAsync(object id);

        IEnumerable<TEntity> GetAll();
        IList<TEntityDTO> GetAllDTO();

        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IList<TEntityDTO>> GetAllDTOAsync();
    }
}
