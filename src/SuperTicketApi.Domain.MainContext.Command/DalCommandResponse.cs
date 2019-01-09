using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTicketApi.Domain.MainContext.Command
{
    public class DalCommandResponse
    {
        public DalCommandResponse()
        {
            isSuccess = false;
        }

        public bool isSuccess { get; set; }
        public string Message { get; set; }
        public Object Object { get; set; }

        public IEnumerable<string> DbValidationErrors;
    }
}
