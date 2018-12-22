namespace SuperTicketApi.Infrastructure.Crosscutting.Tests.Classes
{
    using System.ComponentModel.DataAnnotations;

    class EntityWithValidationAttribute
    {
        [Required(ErrorMessage = "This is a required property")]
        public string RequiredProperty { get; set; }
    }
}
