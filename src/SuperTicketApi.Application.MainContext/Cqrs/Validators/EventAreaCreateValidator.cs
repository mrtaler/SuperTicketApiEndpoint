namespace SuperTicketApi.Application.MainContext.Cqrs.Validators
{
    using FluentValidation;
    using MediatR;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Create;
    using SuperTicketApi.Domain.MainContext.DTO.Attributes;
    using SuperTicketApi.Domain.MainContext.Queries;
    using System.Threading.Tasks;

    /// <para><c>SQL:</c>TABLE [dbo].[EventAreas]</para>
    [DbTable("EventAreas")]
    public class EventAreaCreateValidator : AbstractValidator<PresenterCreateEventAreaCommand>
    {
        /// <summary>
        /// The mediator.
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventArea"/> class.
        /// </summary>
        public EventAreaCreateValidator(IMediator mediator)
        {
            this.mediator = mediator;

            // <para><c>SQL:</c>[EventId] <see langword="int"/> NOT NULL.</para>
            this.RuleFor(x => x.EventId)
                .NotEmpty()
                .WithMessage("Please set an EventId")
                .Must((int id) => this.IsExist(id).Result)
                .WithMessage(x => $"{x.EventId} no exists");
                
            // <para><c>SQL:</c>[Description] nvarchar(200) NOT NULL.</para>
            this.RuleFor(x => x.Description)
                .NotEmpty()
                .Length(3, 200)
                .WithMessage("descripton must be bewtween 3-200 characters in length");


            // <para><c>SQL:</c>[CoordX] <see langword="int"/> NOT NULL.</para>
            this.RuleFor(x => x.CoordX)
                    .NotEmpty();


            /// <para><c>SQL:</c>[CoordY] <see langword="int"/> NOT NULL.</para>

            this.RuleFor(x => x.CoordY)
                    .NotEmpty();


            /// <para><c>SQL:</c>[Price] <see langword="decimal"/>(18, 2) NOT NULL.</para>

            this.RuleFor(x => x.Price)
                    .NotEmpty();

        }
        private async Task<bool>  IsExist(int idToCheck)
        {
            var accountDetails = await this.mediator.Send(
               ByIdSingleQueryPattern.GetSingleEventQuery(idToCheck));

            var result = accountDetails.Id != 0;
            return result;
        }
    }
}
