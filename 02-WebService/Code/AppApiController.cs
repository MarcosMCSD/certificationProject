using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace _02_WebService.Code
{
    public abstract class AppApiController : ApiController
    {
        /// <summary>
        /// Gets the current user.
        /// </summary>
        /// <value>
        /// The current user.
        /// </value>
        public AppUser CurrentUser
        {
            get
            {
                return new AppUser(this.User as ClaimsPrincipal);
            }
        }

        /// <summary>
        /// Forbiddens this instance.
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Forbidden()
        {
            return new System.Web.Http.Results.ResponseMessageResult(Request.CreateErrorResponse(HttpStatusCode.Forbidden, string.Empty));
        }
    }
}