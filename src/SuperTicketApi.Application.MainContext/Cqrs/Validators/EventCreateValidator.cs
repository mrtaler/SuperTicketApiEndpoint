namespace SuperTicketApi.Application.MainContext.Cqrs.Validators
{
    using FluentValidation;
    using MediatR;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Create;
    using SuperTicketApi.Domain.MainContext.DTO.Attributes;

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
                .Length(3, 200).WithMessage("Arar descripton must be bewtween 3-120 characters in length")
                .Must(this.NotExist).WithMessage(x => $"{x.Description} already exists");

            // <para><c>SQL:</c>[Banner] nvarchar(max) NOT NULL.</para>
            this.RuleFor(x => x.Banner)
                .NotEmpty();

            // <para><c>SQL:</c>[Description] nvarchar(max) NOT NULL.</para>
            this.RuleFor(x => x.Description)
                .NotEmpty();

            /// <para><c>SQL:</c>[StartAt] DATETIME NOT NULL.</para>
            this.RuleFor(x => x.StartAt)
                .NotEmpty();

            /// <para><c>SQL:</c>[Runtime] TIME(7) NOT NULL.</para>
            this.RuleFor(x => x.RunTime)
                .NotEmpty();

            this.RuleFor(x => x.LayoutId)
                .NotEmpty()
                .Must(this.IsExist).WithMessage(x => $"{x.Description} already exists");
        }

        private bool IsExist(int idToCheck)
        {
            return false;
        }

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
