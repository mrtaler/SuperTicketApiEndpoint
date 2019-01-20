namespace SuperTicketApi.Application.MainContext.Cqrs.Validators
{
    using FluentValidation;
    using MediatR;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Create;
    using SuperTicketApi.Domain.MainContext.DTO.Attributes;
    using SuperTicketApi.Domain.MainContext.Queries;
    using System.Threading.Tasks;

    /// <summary>
    /// The event.
    /// </summary>
    /// <remarks>
    /// <para><c>SQL:</c>TABLE [dbo].[Events]</para>
    /// </remarks>
    [DbTable("Events")]
    public class EventCreateValidator : AbstractValidator<PresenterCreateEventCommand>
    {
        /// <summary>
        /// The mediator.
        /// </summary>
        private readonly IMediator mediator;

        public EventCreateValidator(IMediator mediator)
        {
            this.mediator = mediator;

            this.RuleFor(x => x.Name)
                .NotEmpty()
                .Length(3, 120)
                .WithMessage("name must be bewtween 3-120 characters in length")                ;

            // <para><c>SQL:</c>[Banner] nvarchar(max) NOT NULL.</para>
            this.RuleFor(x => x.Banner)
                .NotEmpty();

            // <para><c>SQL:</c>[Description] nvarchar(max) NOT NULL.</para>
            this.RuleFor(x => x.Description)
                .NotEmpty();

            // <para><c>SQL:</c>[StartAt] DATETIME NOT NULL.</para>
            this.RuleFor(x => x.StartAt)
                .NotEmpty();

            // <para><c>SQL:</c>[Runtime] TIME(7) NOT NULL.</para>
            this.RuleFor(x => x.RunTime)
                .NotEmpty();

            this.RuleFor(x => x.LayoutId)
                .NotEmpty()
                .Must((int id) => this.IsExist(id).Result)
                .WithMessage(x => $"{x.LayoutId} no exists");
        }

        private async Task<bool> IsExist(int idToCheck)
        {
            var accountDetails = await this.mediator.Send(
             ByIdSingleQueryPattern.GetSingleLayoutQuery(idToCheck));

            var result = accountDetails.Id != 0;
            return result;
        }
    }
}
