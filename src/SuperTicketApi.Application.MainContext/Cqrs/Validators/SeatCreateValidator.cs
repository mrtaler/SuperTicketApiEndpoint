namespace SuperTicketApi.Application.MainContext.Cqrs.Validators
{
    using FluentValidation;
    using MediatR;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Create;
    using SuperTicketApi.Domain.MainContext.DTO.Attributes;

    /// <summary>
    /// The seat.
    /// </summary>
    /// <remarks>
    /// <para><c>SQL:</c>TABLE [dbo].[Seats]</para>
    /// </remarks>
    [DbTable("Seats")]
    public class SeatCreateValidator : AbstractValidator<PresenterCreateSeatCommand>
    {
        /// <summary>
        /// The mediator.
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="Seat"/> class.
        /// </summary>
        public SeatCreateValidator(IMediator mediator)
        {
            this.mediator = mediator;

            /// <para><c>SQL:</c>[AreaId] <see langword="int"/> NOT NULL</para>

            this.RuleFor(x => x.AreaId)
                                .NotEmpty();

            /// <para><c>SQL:</c>[Row] <see langword="int"/> NOT NULL</para>

            this.RuleFor(x => x.Row)
                                 .NotEmpty();

            /// <para><c>SQL:</c>[Number] <see langword="int"/> NOT NULL</para>
            this.RuleFor(x => x.Number)
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
