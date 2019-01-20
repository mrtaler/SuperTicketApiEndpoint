namespace SuperTicketApi.Application.MainContext.Cqrs.Validators
{
    using FluentValidation;
    using MediatR;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Create;
    using SuperTicketApi.Domain.MainContext.Queries;
    using System.Threading.Tasks;

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
        /// Initializes a new instance of the <see cref="AreasCreateValidator"/> class. 
        /// </summary>
        /// <param name="mediator">
        /// The mediator.
        /// </param>
        public AreasCreateValidator(IMediator mediator)
        {
            this.mediator = mediator;

            this.RuleFor(x => x.LayoutId)
                .NotEmpty()
                .WithMessage("Please set an LayoutId")
                .Must((int id) => this.IsExist(id).Result)
                .WithMessage(x => $"{x.LayoutId} no exists");
            this.RuleFor(x => x.Description)
                .Length(3, 200)
                .WithMessage("Arar descripton must be bewtween 3-200 characters in length");
            this.RuleFor(x => x.CoordX)
                .NotEmpty()
                .WithMessage("Please set an CoordX");
            this.RuleFor(x => x.CoordY)
                .NotEmpty()
                .WithMessage("Please set an CoordY");
        }

        /// <summary>
        /// The is exist.
        /// </summary>
        /// <param name="idToCheck">
        /// The id to check.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        private async Task<bool> IsExist(int idToCheck)
        {
            var accountDetails = await this.mediator.Send(
                ByIdSingleQueryPattern.GetSingleLayoutQuery(idToCheck));

            var result = accountDetails.Id != 0;
            return result;
        }
    }
}
