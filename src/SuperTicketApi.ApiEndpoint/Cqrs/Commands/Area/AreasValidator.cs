﻿using FluentValidation;
using MediatR;

namespace SuperTicketApi.ApiEndpoint.Cqrs.Commands.Area
{
    public class AreasValidator : AbstractValidator<PresenterCreateAreaCommand>
    {
        private readonly IMediator _mediator;
        public AreasValidator(IMediator mediator)
        {
            _mediator = mediator;

            RuleFor(x => x.LayoutId)
                .NotEmpty()
                .WithMessage("Please set an LayoutId");
            RuleFor(x => x.Description)
                .Length(3, 200).WithMessage("Arar descripton must be bewtween 3-200 characters in length")
                .Must(NotExist).WithMessage(x => $"{x.Description} already exists");
            RuleFor(x => x.CoordX)
                .NotEmpty().WithMessage("Please set an CoordX");
            RuleFor(x => x.CoordY)
                .NotEmpty().WithMessage("Please set an CoordY");
        }

        private bool NotExist(string description)
        {
            //=========================================================================
            // VALIDATE ACCOUNT NAME IS UNIQUE (Via MediatR Query)
            //=========================================================================
            // Note: "NameKey" is transformed from "Name" and is used as a both a unique id as well as for pretty routes/urls
            // Note: Consider using both "Name and ""NameKey" as UniqueKeys on your DocumentDB collection.
            //-------------------------------------------------------------------------
            // Note: Once these contraints are in place you could remove this manual check
            //  - however this process does ensure no exceptions are thrown and a cleaner response message is sent to the user.
            //----------------------------------------------------------------------------

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