namespace SuperTicketApi.Application.MainContext.Cqrs.Commands.Create
{
    using System;

    using MediatR;

    /// <summary>
    /// The presenter create event command.
    /// </summary>
    public class PresenterCreateEventCommand : IRequest<ApplicationCommandResponse>, IBusinessCommand
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the banner.
        /// </summary>
        public string Banner { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the start at.
        /// </summary>
        public DateTime StartAt { get; set; }

        /// <summary>
        /// Gets or sets the run time.
        /// </summary>
        public TimeSpan RunTime { get; set; }

        /// <summary>
        /// Gets or sets the layout id.
        /// </summary>
        public int LayoutId { get; set; }
    }
}