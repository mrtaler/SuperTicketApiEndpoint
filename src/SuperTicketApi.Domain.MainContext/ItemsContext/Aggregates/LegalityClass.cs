namespace SuperTicketApi.Domain.MainContext.ItemsContext.Aggregates
{
    using SuperTicketApi.Domain.Seedwork;

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
}