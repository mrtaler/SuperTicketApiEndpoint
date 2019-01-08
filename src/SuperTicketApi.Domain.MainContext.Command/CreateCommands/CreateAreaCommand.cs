using MediatR;
using SuperTicketApi.Domain.MainContext.DTO.Models;

namespace SuperTicketApi.Domain.MainContext.Command.CreateCommands
{
    public class CreateAreaCommand : IRequest<DalCommandResponse>
    {
        public int LayoutId { get; set; }
        public string Description { get; set; }
        public int CoordX { get; set; }
        public int CoordY { get; set; }
    }

    public class CreateCustomAreaCommand : Area, IRequest<DalCommandResponse>
    {
        CreateCustomAreaCommand()
        {
            //CoordX
        }
    }
}