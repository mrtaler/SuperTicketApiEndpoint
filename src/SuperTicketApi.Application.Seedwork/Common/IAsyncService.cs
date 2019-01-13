namespace SuperTicketApi.Application.Seedwork.Common
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SuperTicketApi.Application.BoundedContext.DTO;
    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.Seedwork;

    using IBusinessDto = SuperTicketApi.Application.Seedwork.IBusinessDto;

    public interface IAsyncService<TEntity, TEntityDto> : IDisposable
        where TEntity : DomainEntity
        where TEntityDto : IBusinessDto
    {

        Task<TEntity> GetAsync(object id);
        Task<TEntityDto> GetDtoAsync(object id);

        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IList<TEntityDto>> GetAllDtoAsync();

        Task<TEntity> AddAsync(TEntity item);
        Task<TEntityDto> AddAsync(TEntityDto item);

        Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> items);
        Task<IList<TEntityDto>> AddAsync(IList<TEntityDto> item);

        Task RemoveAsync(TEntity item);
        Task RemoveAsync(TEntityDto item);
        Task RemoveAsync(object id);

        Task RemoveAsync(IEnumerable<TEntity> items);
        Task RemoveAsync(IList<TEntityDto> items);
        Task RemoveAsync(IEnumerable<object> ids);


        Task<TEntity> ModifyAsync(TEntity item);
        Task<TEntityDto> ModifyAsync(TEntityDto item);

        Task<IEnumerable<TEntity>> ModifyAsync(IEnumerable<TEntity> items);
        Task<IList<TEntityDto>> ModifyAsync(IList<TEntityDto> items);

        Task<TEntity> ModifyAsync(object id, TEntity item);
        Task<TEntityDto> ModifyAsync(object id, TEntityDto item);
    }
}