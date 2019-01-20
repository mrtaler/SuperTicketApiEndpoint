namespace SuperTicketApi.Application.MainContext.Cqrs.Validators
{
    using FluentValidation;
    using MediatR;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Create;
    using SuperTicketApi.Domain.MainContext.DTO.Attributes;
    using SuperTicketApi.Domain.MainContext.Queries;
    using System.Threading.Tasks;

    /// <summary>
    /// The event seat.
    /// </summary>
    /// <remarks>
    /// <para><c>SQL:</c>TABLE [dbo].[EventSeats]</para>
    /// </remarks>
    [DbTable("EventSeats")]
    public class EventSeatCreateValidator : AbstractValidator<PresenterCreateEventSeatCommand>
    {
        /// <summary>
        /// The mediator.
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventSeat"/> class.
        /// </summary>
        public EventSeatCreateValidator(IMediator mediator)
        {
            this.mediator = mediator;

            /// <para><c>SQL:</c>[EventAreaId] <see langword="int"/> NOT NULL,.</para>

            this.RuleFor(x => x.EventAreaId)
              .Must((int id) => this.IsExist(id).Result)
                .WithMessage(x => $"{x.EventAreaId} no exists")
                    .NotEmpty();


            /// <para><c>SQL:</c>[Row] <see langword="int"/> NOT NULL.</para>

            this.RuleFor(x => x.Row)
                    .NotEmpty();

            /// <para><c>SQL:</c>[Number] <see langword="int"/> NOT NULL.</para>

            this.RuleFor(x => x.Number)
                    .NotEmpty();


            /// <para><c>SQL:</c>[State] <see langword="int"/> NOT NULL.</para>

            this.RuleFor(x => x.State)
                     .NotEmpty();
        }
        private async Task<bool> IsExist(int idToCheck)
        {
            var accountDetails = await this.mediator.Send(
                ByIdSingleQueryPattern.GetSingleEventAreaQuery(idToCheck));

            var result = accountDetails.Id != 0;
            return result;
        }
    }
}
