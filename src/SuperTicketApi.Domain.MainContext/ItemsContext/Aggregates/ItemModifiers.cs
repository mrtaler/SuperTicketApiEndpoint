namespace SuperTicketApi.Domain.MainContext.ItemsContext.Aggregates
{
    using System;

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
}