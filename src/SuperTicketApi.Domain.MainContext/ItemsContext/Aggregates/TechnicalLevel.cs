namespace SuperTicketApi.Domain.MainContext.ItemsContext.Aggregates
{
    using SuperTicketApi.Domain.Seedwork;

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

        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        public virtual Item Item { get; set; }
    }
}