namespace SuperTicketApi.Application.Seedwork.Common
{
    using SuperTicketApi.Domain.Seedwork;

    using IBusinessDto = SuperTicketApi.Application.Seedwork.IBusinessDto;

    public interface IService<TEntity, TEntityDto> : 
        IReadableService<TEntity, TEntityDto>, 
        IEditableService<TEntity, TEntityDto>
        where TEntity : DomainEntity
        where TEntityDto : IBusinessDto
    {
    }
}
