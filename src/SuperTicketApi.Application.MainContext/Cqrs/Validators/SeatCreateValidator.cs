namespace SuperTicketApi.Application.MainContext.Cqrs.Validators
{
    using FluentValidation;
    using MediatR;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Create;
    using SuperTicketApi.Domain.MainContext.Queries;
    using System.Threading.Tasks;

    /// <summary>
    /// The seat.
    /// </summary>
    public class SeatCreateValidator : AbstractValidator<PresenterCreateSeatCommand>
    {
        /// <summary>
        /// The mediator.
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="SeatCreateValidator"/> class. 
        /// </summary>
        /// <param name="mediator">
        /// The mediator.
        /// </param>
        public SeatCreateValidator(IMediator mediator)
        {
            this.mediator = mediator;

            // <para><c>SQL:</c>[AreaId] <see langword="int"/> NOT NULL</para>
            this.RuleFor(x => x.AreaId)
                .Must((int id) => this.IsExist(id).Result)
                .WithMessage(x => $"{x.AreaId} no exists")
                .NotEmpty();

            // <para><c>SQL:</c>[Row] <see langword="int"/> NOT NULL</para>
            this.RuleFor(x => x.Row)
                .NotEmpty();

            // <para><c>SQL:</c>[Number] <see langword="int"/> NOT NULL</para>
            this.RuleFor(x => x.Number)
                .NotEmpty();
        }


        private async Task<bool> IsExist(int idToCheck)
        {
            var accountDetails = await this.mediator.Send(
            ByIdSingleQueryPattern.GetSingleAreaQuery(idToCheck));

            var result = accountDetails.Id != 0;
            return result;
        }
    }
}
