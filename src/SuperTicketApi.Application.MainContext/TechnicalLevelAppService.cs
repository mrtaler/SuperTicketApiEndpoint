namespace SuperTicketApi.Application.MainContext
{
    using Serilog;
    using SuperTicketApi.Application.BoundedContext.DTO;
    using SuperTicketApi.Application.Seedwork;
    using SuperTicketApi.Domain.MainContext.ItemsContext.Aggregates;
    using SuperTicketApi.Infrastructure.Crosscutting.Localization;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TechnicalLevelAppService
     : ITechnicalLevelAppService
    {
        #region Members

        /// <summary>
        /// The item repository.
        /// </summary>
        private readonly ITechnicalLevelRepository technicalLevelRepository;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// The resources.
        /// </summary>
        private readonly ILocalization resources;

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
        public TechnicalLevelAppService(
            ITechnicalLevelRepository technicalLevelRepository, // the bank account repository dependency
            ILogger logger)
        {
            // check preconditions
            this.technicalLevelRepository = technicalLevelRepository
                                  ?? throw new ArgumentNullException("bankAccountRepository");

            this.logger = logger.ForContext<TechnicalLevelAppService>();
            this.resources = LocalizationFactory.CreateLocalResources();
        }

        #endregion

        #region IBankAppService Members

        /// <inheritdoc />
        public IEnumerable<TechnicalLevelDto> GetAllItems()
        {
            var items = this.technicalLevelRepository.GetAll();
            if (items != null && items.Any())
            {
                return items.ProjectedAsCollection<TechnicalLevelDto>();
            }

            return new List<TechnicalLevelDto>();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            // dispose all resources
            this.technicalLevelRepository.Dispose();
        }

        #endregion
    }
}
