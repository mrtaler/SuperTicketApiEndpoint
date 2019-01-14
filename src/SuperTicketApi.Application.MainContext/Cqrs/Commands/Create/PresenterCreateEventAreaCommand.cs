namespace SuperTicketApi.Application.MainContext.Cqrs.Commands.Create
{
    using MediatR;

    /// <summary>
    /// The presenter create event area command.
    /// </summary>
    public class PresenterCreateEventAreaCommand : IRequest<CommandResponse>, IBusinessCommand
    {
        /// <summary>
        /// Gets or sets the event id.
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the coordX.
        /// </summary>
        public int CoordX { get; set; }

        /// <summary>
        /// Gets or sets the coordY.
        /// </summary>
        public int CoordY { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public decimal Price { get; set; }

        #region Command Authorization Options

        /*------------------------------------------------------------------------------------------
        * Authorization Properties (To be managed via 'AuthorizationBehavior' Pipeline Behavior)
        * ----------------------------------------------------------------------------------------*/

        /*
        public CreateAreaCommand()
        {
            Exemption = true;
            MinimumRole = FromRolesList.Role;
        }
        
        public string UserName { get; set; }
        public string UserID { get; set; }
        public string UserType { get; set; } //<-- Account/Platform
        private string MinimumRole { get; set; } //<-- Minumum Role to run function
        private bool Exemption { get; set; } //<-- Allows for exemptions
            
         */
        #endregion
    }
}