namespace SuperTicketApi.Application.MainContext
{
    using System;
    using System.Collections.Generic;

    using SuperTicketApi.Application.BoundedContext.DTO;

    public interface IItemAppService : IDisposable
    {
        /// <summary>
        /// Add new bank acccount
        /// </summary>
        /// <param name="bankAccountDto">The bank account representation to add</param>
        /// <returns>Added bank account</returns>
        ItemDto AddItem(ItemDto bankAccountDto);

        IEnumerable<ItemDto> GetAllItems();
    }
}
