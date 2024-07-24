using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using MyToolsMag.DataAccess.CQRS;
using MyToolsMag.DataAccess.CQRS.Queries;
using MyToolsMag.DataAccess.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyToolsMag.ApplicationServices.Components.PasswordHasher;
using Microsoft.AspNetCore.Identity;

namespace MyToolsMag.Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IPasswordHasher passwordHasher;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IQueryExecutor queryExecutor,
            IPasswordHasher passwordHasher)
            : base(options, logger, encoder, clock)
        {
            this.queryExecutor = queryExecutor;
            this.passwordHasher = passwordHasher;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // skip authentication if endpoint has [AllowAnonymous] attribute
            var endpoint = Context.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
            {

                return AuthenticateResult.NoResult();
            }

            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Missing Authorization Header");
            }

            Admin user = null;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                var username = credentials[0];
                var query = new GetAdminQuery()
                {
                    Username = username
                };
                user = await this.queryExecutor.Execute(query);

                // TODO: HASH!
                if (user == null)
                    return AuthenticateResult.Fail("Resource does not exist");

                var password = passwordHasher.HashToCheck(credentials[1], user.Salt);
                if (user.Password != password)
                {
                    return AuthenticateResult.Fail("Wrong password");
                }
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }
    }
}
