using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace _02_WebService.Code
{
    public class ApiAuthorizedRoles : AuthorizeAttribute
    {
        public ApiAuthorizedRoles(params string[] roles)
        {
            Roles = String.Join(",", roles);
        }

        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var response = new System.Net.Http.HttpResponseMessage();
            response.StatusCode = System.Net.HttpStatusCode.Forbidden;
            response.Content = new System.Net.Http.StringContent("Error");
            actionContext.Response = response;
            return;
        }
    }
}