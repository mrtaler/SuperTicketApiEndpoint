namespace SuperTicketApi.Infrastructure.Crosscutting.Implementation.Validator
{
    using SuperTicketApi.Infrastructure.Crosscutting.Validator;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    /// <summary>
    /// Validator based on Data Annotations. 
    /// This validator use <c>IValidatableObject</c> <c>interface</c> and
    /// ValidationAttribute ( <c>hierarchy</c> of <c>this</c>) for
    /// perform validation
    /// </summary>
    public class DataAnnotationsEntityValidator
        : IEntityValidator
    {
        #region IEntityValidator Members

        /// <summary>
        /// The is valid.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <typeparam name="TEntity">Validated entity
        /// </typeparam>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsValid<TEntity>(TEntity item) where TEntity : class
        {
            if (item == null)
            {
                return false;
            }


            List<string> validationErrors = new List<string>();

            this.SetValidatableObjectErrors(item, validationErrors);
            this.SetValidationAttributeErrors(item, validationErrors);

            return !validationErrors.Any();
        }

        /// <summary>
        /// The get invalid messages.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <typeparam name="TEntity">t t
        /// </typeparam>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<string> GetInvalidMessages<TEntity>(TEntity item) where TEntity : class
        {
            if (item == null)
            {
                return null;
            }

            List<string> validationErrors = new List<string>();

            this.SetValidatableObjectErrors(item, validationErrors);
            this.SetValidationAttributeErrors(item, validationErrors);


            return validationErrors;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get <paramref name="errors"/> if object implement IValidatableObject
        /// </summary>
        /// <typeparam name="TEntity">The typeof entity</typeparam>
        /// <param name="item">The item to validate</param>
        /// <param name="errors">A collection of current errors</param>
        private void SetValidatableObjectErrors<TEntity>(TEntity item, List<string> errors) where TEntity : class
        {
            if (typeof(IValidatableObject).IsAssignableFrom(typeof(TEntity)))
            {
                var validationContext = new ValidationContext(item, null, null);

                var validationResults = ((IValidatableObject)item).Validate(validationContext);

                errors.AddRange(validationResults.Select(vr => vr.ErrorMessage));
            }
        }

        /// <summary>
        /// Get <paramref name="errors"/> on ValidationAttribute
        /// </summary>
        /// <typeparam name="TEntity">The type of entity</typeparam>
        /// <param name="item">The entity to validate</param>
        /// <param name="errors">A collection of current errors</param>
        private void SetValidationAttributeErrors<TEntity>(TEntity item, List<string> errors) where TEntity : class
        {
            var result = from property in TypeDescriptor.GetProperties(item).Cast<PropertyDescriptor>()
                         from attribute in property.Attributes.OfType<ValidationAttribute>()
                         where !attribute.IsValid(property.GetValue(item))
                         select attribute.FormatErrorMessage(string.Empty);

            if (result != null && result.Any())
            {
                errors.AddRange(result);
            }
        }

        #endregion
    }
}
