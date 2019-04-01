using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Application.API.Middleware
{
    public class MyIpRateLimiteMiddleware : IpRateLimitMiddleware
    {
        public MyIpRateLimiteMiddleware(RequestDelegate next, IOptions<IpRateLimitOptions> options, IRateLimitCounterStore counterStore, IIpPolicyStore policyStore, IRateLimitConfiguration config, ILogger<IpRateLimitMiddleware> logger) : base(next, options, counterStore, policyStore, config, logger)
        {
        }

        public override Task ReturnQuotaExceededResponse(HttpContext httpContext, RateLimitRule rule, string retryAfter)
        {
            //return base.ReturnQuotaExceededResponse(httpContext, rule, retryAfter);
            string str = string.Format("API calls quata excluded! maximum admitted {0} per {1}", rule.Limit, rule.Period);
            var result = JsonConvert.SerializeObject(new {error = str});
            httpContext.Response.Headers["Retry-After"] = retryAfter;
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = 429;

            return httpContext.Response.WriteAsync(result);
        }
    }
}
