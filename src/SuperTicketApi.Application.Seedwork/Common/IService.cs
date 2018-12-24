namespace SuperTicketApi.Application.Seedwork.Common
{
    using SuperTicketApi.Domain.Seedwork;

    public interface IService<TEntity, TEntityDto> : IReadableService<TEntity, TEntityDto>, IEditableService<TEntity, TEntityDto>
        where TEntity : Entity
        where TEntityDto : Entity
    {
    }
}
