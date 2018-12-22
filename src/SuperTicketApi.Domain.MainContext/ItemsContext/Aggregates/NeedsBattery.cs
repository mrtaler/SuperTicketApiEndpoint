namespace SuperTicketApi.Domain.MainContext.ItemsContext.Aggregates
{
    using System;

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
}