namespace SuperTicketApi.Domain.MainContext.DTO.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IdColumnAttribute : DbColumnAttribute
    {
        public IdColumnAttribute(Type classType):base($"{classType.Name}Id")
        {
        }
    }
}