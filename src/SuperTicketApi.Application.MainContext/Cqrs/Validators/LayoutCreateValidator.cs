namespace SuperTicketApi.Application.MainContext.Cqrs.Validators
{
    using FluentValidation;
    using MediatR;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Create;
    using SuperTicketApi.Domain.MainContext.DTO.Attributes;
    using SuperTicketApi.Domain.MainContext.Queries;
    using System.Threading.Tasks;

    /// <summary>
    /// The layout.
    /// </summary>
    /// <remarks>
    /// <para><c>SQL:</c>TABLE [dbo].[Layouts]</para>
    /// </remarks>
    [DbTable("Layouts")]
    public class LayoutCreateValidator : AbstractValidator<PresenterCreateLayoutCommand>
    {
        /// <summary>
        /// The mediator.
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="Layout"/> class.
        /// </summary>
        public LayoutCreateValidator(IMediator mediator)
        {
            this.mediator = mediator;

            /// <para><c>SQL:</c>[VenueId] <see langword="int"/> NOT NULL.</para>

            this.RuleFor(x => x.VenueId)
               .Must((int id) => this.IsExist(id).Result)
                .WithMessage(x => $"{x.VenueId} already exists")
                           .NotEmpty();

            /// <para><c>SQL:</c>[Description] nvarchar(120) NOT NULL.</para>
            this.RuleFor(x => x.Description)
                  .Length(3, 120).WithMessage("descripton must be bewtween 3-120 characters in length")
                          .NotEmpty();
        }

        private async Task<bool> IsExist(int idToCheck)
        {
            var accountDetails = await this.mediator.Send(
             ByIdSingleQueryPattern.GetSingleVenueQuery(idToCheck));

            var result = accountDetails.Id != 0;
            return result;
        }
    }
}
