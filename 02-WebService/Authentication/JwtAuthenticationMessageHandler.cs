using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace _02_WebService.Authentication
{
    public class JwtAuthenticationMessageHandler : DelegatingHandler
    {
        public const string BearerScheme = "Bearer";

        public string CookieNameToCheckForToken { get; set; }

        protected virtual Task<HttpResponseMessage> BaseSendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken);
        }

        protected virtual string GetTokenStringFromHeader(HttpRequestMessage request)
        {
            var authHeader = request.Headers.Authorization;
            if (authHeader == null) return null;

            if (authHeader.Scheme != BearerScheme)
            {
            }
            else
            {
                return authHeader.Parameter;
            }

            return null;
        }

        protected override Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request,
                CancellationToken cancellationToken
            )
        {
            var tokenStringFromHeader = GetTokenStringFromHeader(request);

            if (string.IsNullOrEmpty(tokenStringFromHeader))
            {
                return BaseSendAsync(request, cancellationToken);
            }

            JwtSecurityTokenAdapter token;
            try
            {
                token = CreateToken(tokenStringFromHeader);
            }
            catch (Exception ex)
            {
                //return BaseSendAsync(request, cancellationToken);
                return CreateResponseMessage("Error validating token", HttpStatusCode.Unauthorized);
            }

            try
            {
                var jwtSecurityTokenHandlerAdapter = new JwtSecurityTokenHandlerAdapter();

                IPrincipal principal = jwtSecurityTokenHandlerAdapter.ValidateToken(token);

                Thread.CurrentPrincipal = principal;
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.User = principal;
                }

            }
            catch (Microsoft.IdentityModel.Tokens.SecurityTokenExpiredException e)
            {
                return CreateResponseMessage("Security token expired exception", (HttpStatusCode)440);
            }
            catch (SecurityTokenSignatureKeyNotFoundException e)
            {
                return CreateResponseMessage("Untrusted signing cert", HttpStatusCode.Unauthorized);
            }
            catch (SecurityTokenInvalidAudienceException e)
            {
                return CreateResponseMessage("Invalid token audience", HttpStatusCode.Unauthorized);
            }
            catch (Microsoft.IdentityModel.Tokens.SecurityTokenValidationException e)
            {
                return CreateResponseMessage("Invalid token", HttpStatusCode.Unauthorized);
            }
            catch (Exception e)
            {
                throw;
            }

            return BaseSendAsync(request, cancellationToken);
        }

        protected virtual Task<HttpResponseMessage> CreateResponseMessage(string message, HttpStatusCode code)
        {
            var response = new HttpResponseMessage(code)
            {
                Content = new StringContent(message)
            };

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        protected virtual void CheckPrincipal(IPrincipal principal, Type transformerType)
        {
            if (principal == null)
            {
                throw new Exception("The principal object returned by the PrincipalTransformer (of type " +
                                    transformerType.FullName + ") cannot be null.");
            }

            if (principal.Identity == null)
            {
                throw new Exception("The principal object returned by the PrincipalTransformer (of type " +
                                    transformerType.FullName + ") must include a non-null Identity.");
            }
        }

        protected virtual JwtSecurityTokenAdapter CreateToken(string tokenString)
        {
            return new JwtSecurityTokenAdapter(tokenString);
        }
    }
}