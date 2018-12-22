namespace SuperTicketApi.Application.BoundedContext.DTO
{
    using System;

    public class ItemDto
    {
        /// <summary>
        /// Gets the item id.
        /// </summary>
        public Guid ItemId { get; set; }

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
        public int MinStrength { get; set; }

        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        public string Link { get; set; }
    }
}
