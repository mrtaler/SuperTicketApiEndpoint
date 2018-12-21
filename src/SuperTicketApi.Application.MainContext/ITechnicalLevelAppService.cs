namespace SuperTicketApi.Application.MainContext
{
    using System;
    using System.Collections.Generic;

    using SuperTicketApi.Application.BoundedContext.DTO;

    public interface ITechnicalLevelAppService : IDisposable
    {
        /// <summary>
        /// Add new bank acccount
        /// </summary>
        /// <param name="bankAccountDTO">The bank account representation to add</param>
        /// <returns>Added bank account</returns>

        IEnumerable<TechnicalLevelDto> GetAllItems();
    }
}
