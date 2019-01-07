using MediatR;
using SuperTicketApi.ApiEndpoint.ViewModel;

namespace SuperTicketApi.ApiEndpoint.Cqrs.Commands.Area
{
    public class CreateAreaCommand : IRequest<CommandResponse>
    {
        public CreateAreaCommand(CreateAreaViewModel createAreaViewModel)
        {

        }
    }
}
