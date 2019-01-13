namespace SuperTicketApi.Application.Seedwork.Common
{
    using SuperTicketApi.Application.BoundedContext.DTO.Dto;
    using SuperTicketApi.Domain.Seedwork;

    public interface IService<TEntity, TEntityDto> : IReadableService<TEntity, TEntityDto>, IEditableService<TEntity, TEntityDto>
        where TEntity : DomainEntity
        where TEntityDto : BusinesEntity
    {
    }
}
