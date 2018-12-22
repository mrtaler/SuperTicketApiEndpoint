namespace SuperTicketApi.Domain.MainContext.ItemsContext.Aggregates
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using SuperTicketApi.Domain.Seedwork;
    using SuperTicketApi.Infrastructure.Crosscutting.Localization;

    /// <summary>
    /// The item.
    /// </summary>
    public class Item : EntityGuid, IValidatableObject
    {
        /// <summary>
        /// The messages.
        /// </summary>
        private ILocalization messages;

        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        public Item()
        {
            this.messages = LocalizationFactory.CreateLocalResources();
        }

        /// <inheritdoc cref="Guid" />
        public Guid ItemId => this.Id;

        /// <summary>
        /// Gets or sets the item name.
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Gets or sets the <see langword="long"/> item name.
        /// </summary>
        public string LongItemName { get; set; }

        /// <summary>
        /// Gets or sets the item description.
        /// </summary>
        public string ItemDescription { get; set; }

        /// <summary>
        /// Gets or sets the item class id.
        /// </summary>
        public int ItemClassId { get; set; }

        /// <summary>
        /// Gets or sets the item weight.
        /// </summary>
        public decimal ItemWeight { get; set; }

        /// <summary>
        /// Gets or sets the item size.
        /// </summary>
        public string ItemSize { get; set; }

        /// <summary>
        /// Gets or sets the item price.
        /// </summary>
        public decimal ItemPrice { get; set; }

        /// <summary>
        /// Gets or sets the technical level id.
        /// </summary>
        public int TechnicalLevelId { get; set; }

        /// <summary>
        /// Gets or sets the legality class id.
        /// </summary>
        public int LegalityClassId { get; set; }

        /// <summary>
        /// Gets or sets the item image.
        /// </summary>
        public byte[] ItemImage { get; set; }

        /// <summary>
        /// Gets or sets the min strength.
        /// </summary>
        public int? MinStrength { get; set; }

        public decimal CountForWeigthCost { get; set; }

        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        public string Link { get; set; }

        public virtual NeedsBattery NeedsBattery { get; set; }

        public virtual ItemProperties ItemProperties { get; set; }

        public virtual ItemModifiers ItemModifiers { get; set; }

        public virtual LegalityClass LegalityClass { get; set; }

        public virtual TechnicalLevel TechnicalLevel { get; set; }

        #region IValidatableObject Members

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (string.IsNullOrEmpty(this.ItemName))
            {
                validationResults.Add(
                    new ValidationResult(
                        this.messages.GetStringResource(
                            LocalizationKeys.Domain.ValidationItemNameCannotBeNull),
                        new[] { "Item" }));
            }

            if (this.LegalityClass is null)
            {
                validationResults.Add(
                    new ValidationResult(
                        this.messages.GetStringResource(
                            LocalizationKeys.Domain.ValidationLegalityClassCannotBeNull),
                        new[] { "Item" }));
            }

            if (this.TechnicalLevel is null)
            {
                validationResults.Add(
                    new ValidationResult(
                        this.messages.GetStringResource(
                            LocalizationKeys.Domain.ValidationTechnicalLevelCannotBeNull),
                        new[] { "Item" }));
            }

            return validationResults;
        }

        #endregion
    }
}