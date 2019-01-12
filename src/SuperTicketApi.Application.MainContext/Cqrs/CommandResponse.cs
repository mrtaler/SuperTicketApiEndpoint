namespace SuperTicketApi.Application.MainContext.Cqrs
{
    using System;
    using System.Collections.Generic;

    using FluentValidation.Results;

    public class CommandResponse
    {
        public CommandResponse()
        {
            this.IsSuccess = false;
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Object { get; set; }

        public IList<ValidationFailure> ValidationErrors;
    }
}
