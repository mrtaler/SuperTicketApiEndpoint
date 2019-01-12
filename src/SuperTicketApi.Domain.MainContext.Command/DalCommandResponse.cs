using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTicketApi.Domain.MainContext.Command
{
    public class DalCommandResponse
    {
        public DalCommandResponse()
        {
            this.isSuccess = false;
        }

        public bool isSuccess { get; set; }
        public string Message { get; set; }
        public object Object { get; set; }

        public IEnumerable<string> DbValidationErrors;
    }
}
