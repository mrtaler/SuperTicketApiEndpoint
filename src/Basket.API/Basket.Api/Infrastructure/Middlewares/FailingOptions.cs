﻿using System.Collections.Generic;

namespace Basket.Api.Infrastructure.Middlewares
{
    public class FailingOptions
    {
        public string ConfigPath = "/Failing";
        public List<string> EndpointPaths { get; set; } = new List<string>();
    }
}
