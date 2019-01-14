namespace SuperTicketApi.Application.MainContext.Cqrs.Commands.Create
{
    using MediatR;

    /// <summary>
    /// The presenter create area command.
    /// </summary>
    public class PresenterCreateAreaCommand : IBusinessCommand, IRequest<CommandResponse>
    {
        /// <summary>
        /// Gets or sets the layout id.
        /// </summary>
        public int LayoutId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the CoordX.
        /// </summary>
        public int CoordX { get; set; }

        /// <summary>
        /// Gets or sets the CoordY.
        /// </summary>
        public int CoordY { get; set; }

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
