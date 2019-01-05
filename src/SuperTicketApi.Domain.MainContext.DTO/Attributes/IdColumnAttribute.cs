namespace SuperTicketApi.Domain.MainContext.DTO.Attributes
{
    using System;

    internal class IdColumnAttribute : DbColumnAttribute
    {
        public IdColumnAttribute(Type classType):base($"{classType.Name}Id")
        {
        }
    }
}