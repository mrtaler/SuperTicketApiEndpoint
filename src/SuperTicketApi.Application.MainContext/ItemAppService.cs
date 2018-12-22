namespace SuperTicketApi.Application.MainContext
{
    using Serilog;
    using SuperTicketApi.Application.BoundedContext.DTO;
    using SuperTicketApi.Domain.MainContext.ItemsContext.Aggregates;
    using SuperTicketApi.Domain.Seedwork.Repository;
    using SuperTicketApi.Infrastructure.Crosscutting.Localization;
    using SuperTicketApi.Infrastructure.Crosscutting.Validator;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SuperTicketApi.Application.Seedwork;

    /// <summary>
    /// The item app service.
    /// </summary>
    public class ItemAppService
       : IItemAppService
    {
        #region Members

        /// <summary>
        /// The item repository.
        /// </summary>
        private readonly IItemRepository itemRepository;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// The resources.
        /// </summary>
        private readonly ILocalization resources;

        /// <summary>
        /// The tl repository.
        /// </summary>
        private readonly IRepository<TechnicalLevel> tecRepository;

        /// <summary>
        /// The lc repository.
        /// </summary>
        private readonly IRepository<LegalityClass> legRepository;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemAppService"/> class. 
        /// Create a new instance 
        /// </summary>
        /// <param name="itemRepository">
        /// The item Repository.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public ItemAppService(
            IItemRepository itemRepository, // the bank account repository dependency
            ILogger logger,
            IRepository<TechnicalLevel> tecRepository,
            IRepository<LegalityClass> legRepository)
        {
            // check preconditions
            this.itemRepository = itemRepository
                ?? throw new ArgumentNullException("bankAccountRepository");

            this.logger = logger.ForContext<ItemAppService>();
            this.tecRepository = tecRepository;
            this.legRepository = legRepository;
            this.resources = LocalizationFactory.CreateLocalResources();
        }

        #endregion

        #region IBankAppService Members

        /// <summary>
        /// The add item.
        /// </summary>
        /// <param name="bankAccountDTO">
        /// The bank account dto.
        /// </param>
        /// <param name="itemDto"></param>
        /// <returns>
        /// The <see cref="ItemDto"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        public ItemDto AddItem(ItemDto itemDto)
        {
            if (itemDto == null)
            {
                throw new ArgumentException(
                    this.resources.GetStringResource(
                        LocalizationKeys.Application.WarningCannotAddNullBankAccountOrInvalidCustomer));
            }

            var tl = this.tecRepository.Get(itemDto.TechnicalLevelId);
            var lc = this.legRepository.Get(itemDto.LegalityClassId);

            // Create account from factory 
            var account = ItemFactory.CreateItem(tl, lc);

            // save bank account
            this.SaveItem(account);

            return account.ProjectedAs<ItemDto>();

            /* else  //the customer for this bank account not exist, cannot create a new bank account
             {
                 throw new InvalidOperationException(
                     _resources.GetStringResource(
                         LocalizationKeys.Application.warning_CannotCreateBankAccountForNonExistingCustomer));
             }*/
        }

        /// <inheritdoc />
        public IEnumerable<ItemDto> GetAllItems()
        {
            var items = this.itemRepository.GetAll();
            if (items != null && items.Any())
            {
                return items.ProjectedAsCollection<ItemDto>();
            }

            return new List<ItemDto>();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            // dispose all resources
            this.itemRepository.Dispose();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The save item.
        /// </summary>
        /// <param name="bankAccount">
        /// The bank account.
        /// </param>
        /// <exception cref="ApplicationValidationErrorsException">val ex
        /// </exception>
        private void SaveItem(Item bankAccount)
        {
            // validate bank account
            var validator = EntityValidatorFactory.CreateValidator();

            // save entity
            if (validator.IsValid<Item>(bankAccount))
            {
                this.itemRepository.Add(bankAccount);
                this.itemRepository.UnitOfWork.Commit();
            }
            else
            {
                // throw validation errors
                throw new ApplicationValidationErrorsException(
                    validator.GetInvalidMessages(bankAccount));
            }
        }

        #endregion
    }
}
