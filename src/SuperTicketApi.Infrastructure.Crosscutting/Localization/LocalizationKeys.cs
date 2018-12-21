namespace SuperTicketApi.Infrastructure.Crosscutting.Localization
{
    public class LocalizationKeys
    {
        public enum Infrastructure
        {
            info_CannotAddNullEntity,
            info_CannotModifyNullEntity,
            info_CannotRemoveNullEntity,
            info_CannotTrackNullEntity,

            exception_NotMapFoundForTypeAdapter,
            exception_RegisterTypeMapConfigurationElementInvalidTypeValue,
            exception_RegisterTypesMapConfigurationInvalidType,

            exception_InvalidEnumeratedType
        };
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

        public enum Application
        {
            validation_BlogDto_Empty_Name,
            validation_BlogDto_Empty_Url,
            validation_BlogDto_Invalid_Rating,

            validation_PostDto_Empty_Title,
            validation_PostDto_Empty_Content,
            validation_PostDto_Invalid_BlogId,

            validation_No_Records_Found_Error,
            validation_Validation_Error,
            validation_Null_Parameters_Error,
            validation_BadRequest,
            validation_Exception,

            exception_ApplicationValidationExceptionDefaultMessage,

            error_CannotPerformTransferInvalidAccounts,
            exception_InvalidCountryIdentifier,
            exception_InvalidCustomerIdentifier,
            exception_InvalidPageIndexOrPageCount,
            info_OrderTotalIsGreaterCustomerCredit,
            warning_CannotAddBookWithNullInformation,
            warning_CannotAddCustomerWithEmptyInformation,
            warning_CannotAddNotValidatedBankAccount,
            warning_CannotAddNullBankAccountOrInvalidCustomer,
            warning_CannotAddOrderWithNullInformation,
            warning_CannotAddSoftwareWithNullInformation,
            warning_CannotCreateBankAccountForInvalidCustomer,
            warning_CannotCreateBankAccountForNonExistingCustomer,
            warning_CannotCreateOrderForNonExistingCustomer,
            warning_CannotGetActivitiesForInvalidOrNotExistingBankAccount,
            warning_CannotGetOrdersFromEmptyCustomerId,
            warning_CannotLockBankAccountWithEmptyIdentifier,
            warning_CannotLockNonExistingBankAccount,
            warning_CannotRemoveCustomerWithEmptyId,
            warning_CannotRemoveNonExistingCustomer,
            warning_CannotUpdateCustomerWithEmptyInformation,
            warning_CannotUpdateNonExistingCustomer,
            warning_InvalidArgumentForFindCustomer,
            warning_InvalidArgumentForFindOrders,
            warning_InvalidArgumentForFindProducts,
            warning_InvalidArgumentsForFindCountries,
            warning_InvalidArgumentsForFindCustomers
        }

        public enum Distributed_Services
        {
            info_OnExecuting,
            info_Parameter,
            info_OnExecuted,
        }
    }
}
