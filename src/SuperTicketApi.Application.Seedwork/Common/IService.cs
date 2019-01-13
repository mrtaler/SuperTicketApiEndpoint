namespace SuperTicketApi.Application.Seedwork.Common
{
    using SuperTicketApi.Application.BoundedContext.DTO;
    using SuperTicketApi.Domain.MainContext.DTO.Models;
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
