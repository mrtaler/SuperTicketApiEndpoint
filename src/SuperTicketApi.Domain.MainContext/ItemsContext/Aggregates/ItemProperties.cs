namespace SuperTicketApi.Domain.MainContext.ItemsContext.Aggregates
{
    using System;

    using SuperTicketApi.Domain.Seedwork;

    /// <summary>
    /// The item properties.
    /// </summary>
    public class ItemProperties : EntityGuid
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
}