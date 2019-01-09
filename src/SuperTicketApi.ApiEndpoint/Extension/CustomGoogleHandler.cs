namespace SuperTicketApi.ApiEndpoint.Extension
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Security.Claims;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.OAuth;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    using Newtonsoft.Json.Linq;

    using SuperTicketApi.ApiSettings.JsonSettings.GoogleOptions;
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="GoogleAuthOptions" />
    public class CustomGoogleHandler : OAuthHandler<GoogleAuthOptions>
    {/// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    /// <param name="logger"></param>
    /// <param name="encoder"></param>
    /// <param name="clock"></param>
        public CustomGoogleHandler(IOptionsMonitor<GoogleAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock)
        { }
        /// <summary>
        /// Creates the ticket asynchronous.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <param name="properties">The properties.</param>
        /// <param name="tokens">The tokens.</param>
        /// <returns></returns>
        /// <exception cref="HttpRequestException">An error occurred when retrieving Google user information ({response.StatusCode}</exception>
        protected override async Task<AuthenticationTicket> CreateTicketAsync(
            ClaimsIdentity identity,
            AuthenticationProperties properties,
            OAuthTokenResponse tokens)
        {
            // Get the Google user
            var request = new HttpRequestMessage(HttpMethod.Get, this.Options.UserInformationEndpoint);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokens.AccessToken);

            var response = await this.Backchannel.SendAsync(request, this.Context.RequestAborted);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"An error occurred when retrieving Google user information ({response.StatusCode}). Please check if the authentication information is correct and the corresponding Google+ API is enabled.");
            }

            var payload = JObject.Parse(await response.Content.ReadAsStringAsync());

            var context = new OAuthCreatingTicketContext(new ClaimsPrincipal(identity), properties, this.Context, this.Scheme, this.Options, this.Backchannel, tokens, payload);
            context.RunClaimActions();

            await this.Events.CreatingTicket(context);
            return new AuthenticationTicket(context.Principal, context.Properties, this.Scheme.Name);
        }

        /// <summary>
        /// Handles the request asynchronous.
        /// </summary>
        /// <returns></returns>
        public override async Task<bool> HandleRequestAsync()
        {
            if (this.Options.CallbackPath == this.Request.Path)
            {
                return await this.HandleRemoteCallbackAsync();
            }

            return false;
        }
        /// <summary>
        /// Handles the remote callback asynchronous.
        /// </summary>
        /// <returns></returns>
        protected virtual async Task<bool> HandleRemoteCallbackAsync()
        {
            var ticket = await this.AuthenticateAsync().ConfigureAwait(false);

            if (ticket == null)
            {
                var errorContext = new RemoteFailureContext(
                    this.Context,
                    this.Scheme,
                    this.Options,
                    new Exception("Invalid return state, unable to redirect."));

                await this.Options.Events.RemoteFailure(errorContext).ConfigureAwait(false);

                if (errorContext.Result.Handled)
                    return true;

                if (errorContext.Result.Skipped)
                    return false;

                this.Context.Response.StatusCode = 500;
                return true;
            }


            return true;
        }
    }
}
