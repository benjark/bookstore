﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace BookStore.Infrastructure
{
    
    public static class UrlExtensions
    {
        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.PathAndQuery().ToString();
    }
    
}
