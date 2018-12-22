namespace SuperTicketApi.Infrastructure.Crosscutting.Tests.Classes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    class EntityWithValidatableObject
        : IValidatableObject
    {
        public string RequiredProperty { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.RequiredProperty))
            {
                validationResults.Add(new ValidationResult("Invalid Required property", new string[] { "RequiredProperty" }));
            }

            return validationResults;
        }
    }
}
