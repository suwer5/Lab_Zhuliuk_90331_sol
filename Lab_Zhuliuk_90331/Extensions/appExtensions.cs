﻿using Lab_Zhuliuk_90331.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_Zhuliuk_90331.Extensions
{
    public static class AppExtensions
    {
        public static IApplicationBuilder UseFileLogging(this IApplicationBuilder app)
        => app.UseMiddleware<LogMiddleware>();
    }

}
