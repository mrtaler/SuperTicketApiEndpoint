using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTicketApi.Domain.MainContext.DTO.New
{
    public class CommandResponse
    {
        public CommandResponse()
        {
            isSuccess = false;
        }

        public bool isSuccess { get; set; }
        public string Message { get; set; }
        public Object Object { get; set; }

        public IList<FluentValidation.Results.ValidationFailure> ValidationErrors;
    }
}
