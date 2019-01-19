namespace SuperTicketApi.Application.MainContext.Cqrs.Validators
{
    using FluentValidation;
    using MediatR;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Create;
    using SuperTicketApi.Domain.MainContext.DTO.Attributes;

    /// <summary>
    /// The venue.
    /// </summary>
    /// <remarks>
    /// <para><c>SQL:</c>[dbo].[Venues]</para>
    /// </remarks>
    [DbTable("Venues")]
    public class VenueCreateValidator : AbstractValidator<PresenterCreateVenueCommand>
    {
        /// <summary>
        /// The mediator.
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="Venue"/> class.
        /// </summary>
        public VenueCreateValidator(IMediator mediator)
        {
            this.mediator = mediator;

            // <para><c>SQL:</c>[Description] nvarchar(120) NOT NULL.</para>
            this.RuleFor(x => x.Description)
                .NotEmpty();

            /// <para><c>SQL:</c>[Address] nvarchar(200) NOT NULL.</para>
            this.RuleFor(x => x.Address)
                .NotEmpty();
            /// <para><c>SQL:</c>[Phone] nvarchar(30).</para>
            this.RuleFor(x => x.Phone)
                .NotEmpty();

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
