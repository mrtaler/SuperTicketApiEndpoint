namespace SuperTicketApi.Infrastructure.Crosscutting.Localization
{
    /// <summary>
    /// The localization keys.
    /// </summary>
    public class LocalizationKeys
    {
        /// <summary>
        /// The infrastructure Localization Keys
        /// </summary>
        public enum Infrastructure
        {
            InfoCannotAddNullEntity,
            InfoCannotModifyNullEntity,
            InfoCannotRemoveNullEntity,
            InfoCannotTrackNullEntity,

            ExceptionNotMapFoundForTypeAdapter,
            ExceptionRegisterTypeMapConfigurationElementInvalidTypeValue,
            ExceptionRegisterTypesMapConfigurationInvalidType,

            ExceptionInvalidEnumeratedType
        }

        /// <summary>
        /// The domain Localization Keys
        /// </summary>
        public enum Domain
        {
            /// <summary>
            /// The validation item name cannot be null.
            /// </summary>
            ValidationItemNameCannotBeNull,

            /// <summary>
            /// The validation technical level cannot be null.
            /// </summary>
            ValidationTechnicalLevelCannotBeNull,

            /// <summary>
            /// The validation legality class cannot be null.
            /// </summary>
            ValidationLegalityClassCannotBeNull,

            /// <summary>
            /// The validation item class cannot be null.
            /// </summary>
            ValidationItemClassCannotBeNull
        }

        /// <summary>
        /// The application Localization Keys
        /// </summary>
        public enum Application
        {
            ValidationBlogDtoEmptyName,
            ValidationBlogDtoEmptyUrl,
            ValidationBlogDtoInvalidRating,

            ValidationPostDtoEmptyTitle,
            ValidationPostDtoEmptyContent,
            ValidationPostDtoInvalidBlogId,

            ValidationNoRecordsFoundError,
            ValidationValidationError,
            ValidationNullParametersError,
            ValidationBadRequest,
            ValidationException,

            ExceptionApplicationValidationExceptionDefaultMessage,

            ErrorCannotPerformTransferInvalidAccounts,
            ExceptionInvalidCountryIdentifier,
            ExceptionInvalidCustomerIdentifier,
            ExceptionInvalidPageIndexOrPageCount,
            InfoOrderTotalIsGreaterCustomerCredit,
            WarningCannotAddBookWithNullInformation,
            WarningCannotAddCustomerWithEmptyInformation,
            WarningCannotAddNotValidatedBankAccount,
            WarningCannotAddNullBankAccountOrInvalidCustomer,
            WarningCannotAddOrderWithNullInformation,
            WarningCannotAddSoftwareWithNullInformation,
            WarningCannotCreateBankAccountForInvalidCustomer,
            WarningCannotCreateBankAccountForNonExistingCustomer,
            WarningCannotCreateOrderForNonExistingCustomer,
            WarningCannotGetActivitiesForInvalidOrNotExistingBankAccount,
            WarningCannotGetOrdersFromEmptyCustomerId,
            WarningCannotLockBankAccountWithEmptyIdentifier,
            WarningCannotLockNonExistingBankAccount,
            WarningCannotRemoveCustomerWithEmptyId,
            WarningCannotRemoveNonExistingCustomer,
            WarningCannotUpdateCustomerWithEmptyInformation,
            WarningCannotUpdateNonExistingCustomer,
            WarningInvalidArgumentForFindCustomer,
            WarningInvalidArgumentForFindOrders,
            WarningInvalidArgumentForFindProducts,
            WarningInvalidArgumentsForFindCountries,
            WarningInvalidArgumentsForFindCustomers
        }

        /// <summary>
        /// The distributed services Localization Keys
        /// </summary>
        public enum DistributedServices
        {
            InfoOnExecuting,
            InfoParameter,
            InfoOnExecuted,
        }
    }
}
