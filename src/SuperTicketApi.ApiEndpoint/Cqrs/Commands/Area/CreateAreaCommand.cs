using MediatR;
using SuperTicketApi.ApiEndpoint.ViewModel;

namespace SuperTicketApi.ApiEndpoint.Cqrs.Commands.Area
{
    public class PresenterCreateAreaCommand : IRequest<CommandResponse>
    {
        public int LayoutId { get; set; }
        public string Description { get; set; }
        public int CoordX { get; set; }
        public int CoordY { get; set; }

        public PresenterCreateAreaCommand(CreateAreaViewModel createAreaViewModel)
        {
            LayoutId = createAreaViewModel.LayoutId;
            Description = createAreaViewModel.Description;
            CoordX = createAreaViewModel.CoordX;
            CoordY = createAreaViewModel.CoordY;
        }

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
