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
        /// <param name="bankAccountDTO">The bank account representation to add</param>
        /// <returns>Added bank account</returns>
        ItemDTO AddItem(ItemDTO bankAccountDTO);

        IEnumerable<ItemDTO> GetAllItems();
    }
}
