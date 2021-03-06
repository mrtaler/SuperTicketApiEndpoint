﻿namespace SuperTicketApi.Application.MainContext.Cqrs.Commands.Create
{
    using MediatR;

    /// <summary>
    /// The presenter create seat command.
    /// </summary>
    public class PresenterCreateSeatCommand : IRequest<ApplicationCommandResponse>, IBusinessCommand
    {
        /// <summary>
        /// Gets or sets the area id.
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// Gets or sets the row.
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        public int Number { get; set; }
    }
}