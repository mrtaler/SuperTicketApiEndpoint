namespace SuperTicketApi.Application.MainContext.Cqrs.Validators
{
    using FluentValidation;
    using MediatR;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Create;

    /// <summary>
    /// The venue.
    /// </summary>
    public class VenueCreateValidator : AbstractValidator<PresenterCreateVenueCommand>
    {
        /// <summary>
        /// The mediator.
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="VenueCreateValidator"/> class. 
        /// </summary>
        /// <param name="mediator">
        /// The mediator.
        /// </param>
        public VenueCreateValidator(IMediator mediator)
        {
            this.mediator = mediator;

            // <para><c>SQL:</c>[Description] nvarchar(120) NOT NULL.</para>
            this.RuleFor(x => x.Description)
                  .Length(3, 120).WithMessage("Description must be between 3-120 characters in length")
                .NotEmpty();

            // <para><c>SQL:</c>[Address] nvarchar(200) NOT NULL.</para>
            this.RuleFor(x => x.Address)
                  .Length(3, 200).WithMessage("Address must be between 3-200 characters in length")
                .NotEmpty();
            
            // <para><c>SQL:</c>[Phone] nvarchar(30).</para>
            this.RuleFor(x => x.Phone)
                  .Length(3, 30).WithMessage("Phone must be between 3-200 characters in length")
                .NotEmpty();
        }
    }
}
