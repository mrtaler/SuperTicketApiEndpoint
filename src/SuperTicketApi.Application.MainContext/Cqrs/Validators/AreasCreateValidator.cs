namespace SuperTicketApi.Application.MainContext.Cqrs.Validators
{
    using FluentValidation;

    using MediatR;

    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Create;

    /// <summary>
    /// The areas validator.
    /// </summary>
    public class AreasCreateValidator : AbstractValidator<PresenterCreateAreaCommand>
    {
        /// <summary>
        /// The mediator.
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="AreasValidator"/> class.
        /// </summary>
        /// <param name="mediator">
        /// The mediator.
        /// </param>
        public AreasCreateValidator(IMediator mediator)
        {
            this.mediator = mediator;

            this.RuleFor(x => x.LayoutId)
                .NotEmpty()
                .WithMessage("Please set an LayoutId");
            this.RuleFor(x => x.Description)
                .Length(3, 200).WithMessage("Arar descripton must be bewtween 3-200 characters in length")
                .Must(this.NotExist).WithMessage(x => $"{x.Description} already exists");
            this.RuleFor(x => x.CoordX)
                .NotEmpty().WithMessage("Please set an CoordX");
            this.RuleFor(x => x.CoordY)
                .NotEmpty().WithMessage("Please set an CoordY");
        }

        /// <summary>
        /// The not exist.
        /// </summary>
        /// <param name="description">
        /// The description.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool NotExist(string description)
        {
            // =========================================================================
            // VALIDATE ACCOUNT NAME IS UNIQUE (Via MediatR Query)
            // =========================================================================
            // Note: "NameKey" is transformed from "Name" and is used as a both a unique id as well as for pretty routes/urls
            // Note: Consider using both "Name and ""NameKey" as UniqueKeys on your DocumentDB collection.
            // -------------------------------------------------------------------------
            // Note: Once these contraints are in place you could remove this manual check
            // - however this process does ensure no exceptions are thrown and a cleaner response message is sent to the user.
            // ----------------------------------------------------------------------------

            /*var accountDetailsQuery = new GetAccountDetailsQuery { NameKey = Common.Transformations.NameKey.Transform(name) };
            var accountDetails = _mediator.Send(accountDetailsQuery);

            if (accountDetails.Result.Account != null)
            {
                return false;
            }*/
            return true;
        }
    }
}
