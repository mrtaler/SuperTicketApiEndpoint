using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTicketApi.Domain.MainContext.DTO.New
{
    using FluentValidation.Results;

    public class CommandResponse
    {
        public CommandResponse()
        {
            this.isSuccess = false;
        }

        public bool isSuccess { get; set; }
        public string Message { get; set; }
        public object Object { get; set; }

        public IList<ValidationFailure> ValidationErrors;
    }
}
