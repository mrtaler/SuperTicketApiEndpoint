namespace SuperTicketApi.Application.MainContext.Cqrs
{
    using System.Collections.Generic;

    using FluentValidation.Results;

    public class ApplicationCommandResponse
    {
        public ApplicationCommandResponse()
        {
            this.IsSuccess = false;
            ValidationErrors = new List<ValidationFailure>();
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Object { get; set; }

        public IList<ValidationFailure> ValidationErrors;
    }
}
