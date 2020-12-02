﻿using System.Net;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Firewall;

namespace BasicApp
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseForwardedHeaders(
                new ForwardedHeadersOptions
                {
                    ForwardedHeaders = ForwardedHeaders.XForwardedFor,
                    ForwardLimit = 1
                }
            );

            // Register Firewall after error handling and forwarded headers,
            // but before other middleware:
            var allowedIPAddresses =
                new List<IPAddress>
                    {
                        IPAddress.Parse("10.20.30.40"),
                        IPAddress.Parse("1.2.3.4"),
                        IPAddress.Parse("5.6.7.8")
                    };

            var allowedIPAddressRanges =
                new List<CIDRNotation>
                    {
                        CIDRNotation.Parse("110.40.88.12/28"),
                        CIDRNotation.Parse("88.77.99.11/8")
                    };

            app.UseFirewall(
                FirewallRulesEngine
                    .DenyAllAccess()
                    .ExceptFromCountries(new [] { CountryCode.FK })
                    .ExceptFromIPAddressRanges(allowedIPAddressRanges)
                    .ExceptFromIPAddresses(allowedIPAddresses)
                    .ExceptFromCloudflare()
                    .ExceptFromLocalhost(),
                accessDeniedDelegate:
                    ctx =>
                    {
                        ctx.Response.StatusCode = StatusCodes.Status403Forbidden;
                        return ctx.Response.WriteAsync("Forbidden");
                    });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
