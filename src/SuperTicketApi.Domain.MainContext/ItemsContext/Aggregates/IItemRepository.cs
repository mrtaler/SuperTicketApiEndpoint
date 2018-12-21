namespace SuperTicketApi.Domain.MainContext.ItemsContext.Aggregates
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using SuperTicketApi.Domain.MainContext.ItemsContext.Aggregates.ItemSpecification;
    using SuperTicketApi.Domain.Seedwork;
    using SuperTicketApi.Domain.Seedwork.Repository;
    using SuperTicketApi.Domain.Seedwork.Specifications.Interfaces;
    using SuperTicketApi.Domain.Seedwork.Specifications.Specifications;
    using SuperTicketApi.Infrastructure.Crosscutting.Localization;

    /// <summary>
    /// The ItemRepository interface.
    /// </summary>
    public interface IItemRepository
        : IRepository<Item>
    {
    }
    public interface ITechnicalLevelRepository
        : IRepository<TechnicalLevel>
    {
    }

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

        public Guid ItemId => this.Id;

        /// <summary>
        /// Gets or sets the item name.
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Gets or sets the long item name.
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

    /// <summary>
    /// The item factory.
    /// </summary>
    public static class ItemFactory
    {
        /// <summary>
        /// The create item.
        /// </summary>
        /// <returns>
        /// The <see cref="Item"/>.
        /// </returns>
        public static Item CreateItem(TechnicalLevel tl, LegalityClass lc)
        {
            var item = new Item();
            item.GenerateNewIdentity();
            item.TechnicalLevel = tl;
            item.LegalityClass = lc;
            return item;
        }
    }

    /// <summary>
    /// The item modifiers.
    /// </summary>
    public class ItemModifiers
    {
        public decimal? LockPickModifier { get; set; }

        public decimal? CrowbarModifier { get; set; }

        public decimal? DisarmModifier { get; set; }

        public decimal? RepairModifier { get; set; }

        public decimal? DamageChance { get; set; }


        public Guid ItemId { get; set; }

        public virtual Item Item { get; set; }
    }

    /// <summary>
    /// The item properties.
    /// </summary>
    public class ItemProperties : ValueObject<ItemProperties>
    {
        public bool Damageable { get; set; }

        public bool Used { get; set; }

        public bool Repairable { get; set; }

        public bool WaterDamages { get; set; }

        public bool Metal { get; set; }

        public bool TwoHanded { get; set; }

        public bool Electronic { get; set; }

        public bool Ht { get; set; }

        public bool Ut { get; set; }

        public bool NeedsBatteries { get; set; }

        public bool HaveFingerPrintId { get; set; }

        public Guid ItemId { get; set; }

        public virtual Item Item { get; set; }
    }
    

    /// <summary>
     /// The item specifications.
     /// </summary>
    public static class ItemSpecifications
    {
        /// <summary>
        /// The item by id.
        /// </summary>
        /// <param name="itemId">
        /// The item id.
        /// </param>
        /// <returns>
        /// The <see cref="ISpecification{T}"/>.
        /// </returns>
        public static ISpecification<Item> ItemById(Guid itemId)
        {
            Specification<Item> specification = new ItemByIdSpecifications(itemId);
            return specification;
        }
    }

    /// <summary>
    /// The legality class.
    /// </summary>
    public class LegalityClass : EntityInt
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LegalityClass"/> class. 
        /// Default constructor (DB load)
        /// </summary>
        public LegalityClass()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LegalityClass"/> class. 
        /// Constructor for new  legality class
        /// </summary>
        /// <param name="name">
        /// name  legality class
        /// </param>
        /// <param name="shortDescription">
        /// The short Description.
        /// </param>
        /// <param name="description">
        /// full description  legality class
        /// </param>
        public LegalityClass(string name, string shortDescription, string description)
        {
            this.Name = name;
            this.ShortDescription = shortDescription;
            this.Description = description;
        }

        /// <summary>
        /// Gets or sets  current id
        /// </summary>
        public int LegalityClassId => this.Id;

        /// <summary>
        /// Gets or sets name  legality class
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Short description  legality class
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets full description  legality class
        /// </summary>
        public string Description { get; set; }

        public virtual Item Item { get; set; }
    }

    /// <summary>
    /// The needs battery.
    /// </summary>
    public class NeedsBattery
    {
        public string SizeBatteries { get; set; }

        public int CountOfBat { get; set; }

        public string WorksOnBat { get; set; }

        public Guid ItemId { get; set; }

        public virtual Item Item { get; set; }
    }

    /// <summary>
    /// The technical level.
    /// </summary>
    public class TechnicalLevel : EntityInt
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TechnicalLevel"/> class. 
        /// Default constructor (for dbLoad)
        /// </summary>
        public TechnicalLevel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TechnicalLevel"/> class. 
        /// Constructor for TechLevel Data
        /// </summary>
        /// <param name="nameTl">
        /// string Tech Level name
        /// </param>
        /// <param name="description">
        /// string Description
        /// </param>
        /// <param name="startMoney">
        /// decimal Start Money
        /// </param>
        public TechnicalLevel(string nameTl, string description, decimal startMoney)
        {
            this.Name = nameTl;
            this.Description = description;
            this.StartMoney = startMoney;
        }

        /// <summary>
        /// Gets or sets Tl Id
        /// </summary>
        public int TechnicalLevelId => this.Id;

        /// <summary>
        /// Gets or sets Name of TechLevel
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Description of Tech Level
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets Start money fo current TechLevel
        /// </summary>
        public decimal StartMoney { get; set; }

        public virtual Item Item { get; set; }
    }
}
