namespace SuperTicketApi.ApiEndpoint.Controllers.Base
{
    using System.Collections.Generic;

    public partial class BaseController
    {
        protected class ApiValidationError
        {
            public ApiValidationError()
            {
                PlaceHolder = new Dictionary<string, string>();
            }
            public string PropertyName { get; set; }
            public string AttemptedValue { get; set; }
            public string ErrorMessage { get; set; }
            public string CustomState { get; set; }
            public string ErrorCode { get; set; }
            public Dictionary<string, string> PlaceHolder { get; set; }
        }


    }
}